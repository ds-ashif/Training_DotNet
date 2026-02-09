using System;
using System.Collections.Generic;
using System.Linq;

namespace FraudDetectionEngine
{
    #region Models

    /// <summary>
    /// Represents a payment transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>Unique transaction id.</summary>
        public string TransactionId { get; set; }

        /// <summary>Card number used.</summary>
        public string CardNumber { get; set; }

        /// <summary>Transaction amount.</summary>
        public decimal Amount { get; set; }

        /// <summary>City where transaction occurred.</summary>
        public string City { get; set; }

        /// <summary>Transaction timestamp.</summary>
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Fraud alert generated after rule violation.
    /// </summary>
    public class FraudAlert
    {
        public string CardNumber { get; set; }
        public string RuleTriggered { get; set; }

        /// <summary>Transactions involved in alert.</summary>
        public List<Transaction> SuspiciousTransactions { get; set; } = new();
    }

    #endregion

    #region Fraud Detection Engine

    /// <summary>
    /// Detects fraud patterns from transaction batches.
    /// </summary>
    public class FraudDetector
    {
        private static readonly TimeSpan HighAmountWindow = TimeSpan.FromMinutes(2);

        private static readonly TimeSpan CityChangeWindow = TimeSpan.FromMinutes(10);

        private const decimal HighAmountThreshold = 50000;

        /// <summary>
        /// Entry method for fraud detection.
        /// </summary>
        public List<FraudAlert> DetectFraud(List<Transaction> txns)
        {
            var alerts = new List<FraudAlert>();

            if (txns == null || txns.Count == 0)
                return alerts;

            // Process per card number
            var grouped = txns
                .OrderBy(t => t.Timestamp)
                .GroupBy(t => t.CardNumber);

            foreach (var cardGroup in grouped)
            {
                var cardTxns = cardGroup.ToList();

                alerts.AddRange( DetectHighAmountBurst(cardGroup.Key, cardTxns));

                alerts.AddRange(DetectCityChange(cardGroup.Key, cardTxns));
            }

            return alerts;
        }

        /// <summary>
        /// Rule 1:
        /// Detect 3+ high value transactions within 2 minutes.
        /// Sliding window approach.
        /// </summary>
        private List<FraudAlert> DetectHighAmountBurst(string card, List<Transaction> transactions)
        {
            var alerts = new List<FraudAlert>();

            // Filter only high value transactions
            var highValueTxns = transactions
                .Where(t => t.Amount > HighAmountThreshold)
                .OrderBy(t => t.Timestamp)
                .ToList();

            int start = 0;

            for (int end = 0; end < highValueTxns.Count; end++)
            {
                // Shrink window if outside 2 min window
                while (highValueTxns[end].Timestamp - highValueTxns[start].Timestamp > HighAmountWindow)
                {
                    start++;
                }

                int windowSize = end - start + 1;

                if (windowSize >= 3)
                {
                    alerts.Add(new FraudAlert
                    {
                        CardNumber = card,
                        RuleTriggered = "3+ high-value transactions within 2 minutes",
                        SuspiciousTransactions =highValueTxns.Skip(start).Take(windowSize).ToList()
                    });

                    // Avoid duplicate alerts
                    start = end;
                }
            }

            return alerts;
        }

        /// <summary>
        /// Rule 2:
        /// Same card used in different cities within 10 minutes.
        /// </summary>
        private List<FraudAlert> DetectCityChange(string card,List<Transaction> transactions)
        {
            var alerts = new List<FraudAlert>();

            for (int i = 1; i < transactions.Count; i++)
            {
                var prev = transactions[i - 1];
                var current = transactions[i];

                // Check city mismatch
                if (!string.Equals(prev.City, current.City,StringComparison.OrdinalIgnoreCase))
                {
                    // Check time difference
                    if (current.Timestamp - prev.Timestamp <= CityChangeWindow)
                    {
                        alerts.Add(new FraudAlert
                        {
                            CardNumber = card,
                            RuleTriggered = "Same card used in multiple cities within 10 minutes",
                            SuspiciousTransactions =new List<Transaction>{prev,current}
                        });
                    }
                }
            }

            return alerts;
        }
    }

    #endregion

    #region Demo Program

    /// <summary>
    /// Demonstrates fraud detection execution.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var txns = new List<Transaction>
            {
                new Transaction
                {
                    TransactionId="T1",
                    CardNumber="1111",
                    Amount=60000,
                    City="Delhi",
                    Timestamp=DateTime.UtcNow
                },
                new Transaction
                {
                    TransactionId="T2",
                    CardNumber="1111",
                    Amount=70000,
                    City="Delhi",
                    Timestamp=DateTime.UtcNow.AddSeconds(40)
                },
                new Transaction
                {
                    TransactionId="T3",
                    CardNumber="1111",
                    Amount=80000,
                    City="Delhi",
                    Timestamp=DateTime.UtcNow.AddSeconds(80)
                },
                new Transaction
                {
                    TransactionId="T4",
                    CardNumber="1111",
                    Amount=1000,
                    City="Mumbai",
                    Timestamp=DateTime.UtcNow.AddMinutes(5)
                }
            };

            var detector = new FraudDetector();

            var alerts = detector.DetectFraud(txns);

            Console.WriteLine($"Fraud alerts detected: {alerts.Count}");

            foreach (var alert in alerts)
            {
                Console.WriteLine($"Rule: {alert.RuleTriggered}");
            }
        }
    }

    #endregion
}
