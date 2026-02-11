// Problem: Create a type-safe medical records system with different patient types and treatments.
// 5. TEST SCENARIO: Simulate hospital workflow
// a) Create 2 PediatricPatient and 2 GeriatricPatient
// b) Add them to priority queue with different priorities
// c) Create medical records with diagnoses/treatments
// d) Prescribe medications with type-specific validation
// e) Demonstrate:
//    - Priority-based patient processing
//    - Age-specific medication validation
//    - Treatment history retrieval
//    - Drug interaction checking

using System;
using System.Collections.Generic;

namespace HospitalPatientManagement
{
    public interface IPatient
    {
        int PatientId { get; }
        string Name { get; }
        DateTime DateOfBirth { get; }
        BloodType BloodType { get; }
    }

    public enum BloodType { A, B, AB, O }
    public enum Condition { Stable, Critical, Recovering }

    // 1. Generic patient queue with priority
    public class PriorityQueue<T> where T : IPatient
    {
        private SortedDictionary<int, Queue<T>> _queues = new();

        // TODO: Enqueue patient with priority (1=highest, 5=lowest)
        public void Enqueue(T patient, int priority)
        {
            // Validate priority range
            if (priority < 1 || priority > 5)
                throw new ArgumentException("Priority must be between 1 and 5.");

            // Create queue if doesn't exist for priority
            if (!_queues.ContainsKey(priority))
                _queues[priority] = new Queue<T>();

            _queues[priority].Enqueue(patient);
        }

        // TODO: Dequeue highest priority patient
        public T Dequeue()
        {
            // Return patient from highest non-empty priority
            // Throw if empty
            foreach (var pair in _queues)
            {
                if (pair.Value.Count > 0)
                    return pair.Value.Dequeue();
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        // TODO: Peek without removing
        public T Peek()
        {
            // Look at next patient
            foreach (var pair in _queues)
            {
                if (pair.Value.Count > 0)
                    return pair.Value.Peek();
            }

            throw new InvalidOperationException("Queue is empty.");
        }

        // TODO: Get count by priority
        public int GetCountByPriority(int priority)
        {
            // Return count for specific priority
            if (_queues.ContainsKey(priority))
                return _queues[priority].Count;

            return 0;
        }
    }

    // 2. Generic medical record
    public class MedicalRecord<T> where T : IPatient
    {
        private T _patient;
        private List<string> _diagnoses = new();
        private Dictionary<DateTime, string> _treatments = new();
        public MedicalRecord(T patient)
        {
            _patient = patient;
        }

        // TODO: Add diagnosis with date
        public void AddDiagnosis(string diagnosis, DateTime date)
        {
            // Add to diagnoses list
            _diagnoses.Add($"{date.ToShortDateString()} - {diagnosis}");
        }

        // TODO: Add treatment
        public void AddTreatment(string treatment, DateTime date)
        {
            // Add to treatments dictionary
            _treatments[date] = treatment;
        }

        // TODO: Get treatment history
        public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
        {
            // Return sorted by date
            List<KeyValuePair<DateTime, string>> list =
            new List<KeyValuePair<DateTime, string>>(_treatments);

            list.Sort((a, b) => a.Key.CompareTo(b.Key));

            return list;
        }
    }

    // 3. Specialized patient types
    public class PediatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public string GuardianName { get; set; }
        public double Weight { get; set; } // in kg
    }

    public class GeriatricPatient : IPatient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public BloodType BloodType { get; set; }
        public List<string> ChronicConditions { get; } = new();
        public int MobilityScore { get; set; } // 1-10
    }

    // 4. Generic medication system
    public class MedicationSystem<T> where T : IPatient
    {
        private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

        // TODO: Prescribe medication with dosage validation
        public void PrescribeMedication(T patient, string medication,
            Func<T, bool> dosageValidator)
        {
            // Check if dosage is valid for patient type
            // Pediatric: weight-based validation
            // Geriatric: kidney function consideration
            if (!dosageValidator(patient))
            {
                Console.WriteLine("Dosage validation failed.");
                return;
            }

            if (!_medications.ContainsKey(patient))
                _medications[patient] = new List<(string, DateTime)>();

            _medications[patient].Add((medication, DateTime.Now));

            Console.WriteLine($"Medication prescribed: {medication}");

        }

        // TODO: Check for drug interactions
        public bool CheckInteractions(T patient, string newMedication)
        {
            // Return true if interaction with existing medications

            if (!_medications.ContainsKey(patient))
                return false;

            foreach (var med in _medications[patient])
            {
                // simple rule example
                if (med.medication == newMedication)
                    return true;
            }

            return false;
        }
    }


    class Program
    {
        static void Main()
        {
            var p1 = new PediatricPatient
            {
                PatientId = 1,
                Name = "Tom",
                DateOfBirth = DateTime.Now.AddYears(-8),
                BloodType = BloodType.A,
                GuardianName = "John",
                Weight = 25
            };

            var p2 = new PediatricPatient
            {
                PatientId = 2,
                Name = "Lucy",
                DateOfBirth = DateTime.Now.AddYears(-6),
                BloodType = BloodType.O,
                GuardianName = "Anna",
                Weight = 18
            };

            var g1 = new GeriatricPatient
            {
                PatientId = 3,
                Name = "Mr. Smith",
                DateOfBirth = DateTime.Now.AddYears(-72),
                BloodType = BloodType.B,
                MobilityScore = 5
            };

            var g2 = new GeriatricPatient
            {
                PatientId = 4,
                Name = "Mrs. Rose",
                DateOfBirth = DateTime.Now.AddYears(-80),
                BloodType = BloodType.AB,
                MobilityScore = 3
            };

            var queue = new PriorityQueue<IPatient>();

            queue.Enqueue(p1, 3);
            queue.Enqueue(g1, 1);
            queue.Enqueue(p2, 2);
            queue.Enqueue(g2, 1);

            Console.WriteLine("Next patient: " + queue.Peek().Name);

            var record = new MedicalRecord<IPatient>(p1);
            record.AddDiagnosis("Flu", DateTime.Today);
            record.AddTreatment("Antiviral Therapy", DateTime.Today);

            Console.WriteLine("\nTreatment History:");
            foreach (var t in record.GetTreatmentHistory())
                Console.WriteLine($"{t.Key:d} - {t.Value}");

            var medSystem = new MedicationSystem<IPatient>();

            medSystem.PrescribeMedication(p1, "PediatricDoseMed",pat => pat is PediatricPatient child && child.Weight > 20);

            medSystem.PrescribeMedication(g1, "SeniorCareMed",pat => pat is GeriatricPatient);

            Console.WriteLine("\nInteraction check:");
            Console.WriteLine(
            medSystem.CheckInteractions(p1, "PediatricDoseMed"));
        }
    }



}