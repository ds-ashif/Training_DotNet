using System;

namespace FactoryRobotHazardAnalyser
{
    /// <summary>
    /// Custom exception used for robot safety validation errors.
    /// </summary>
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Calculates hazard risk score after validating inputs.
    /// </summary>
    public class RobotHazardAuditor
    {
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            // Validate arm precision
            if (armPrecision < 0.0 || armPrecision > 1.0)
            {
                throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
            }

            // Validate worker density
            if (workerDensity < 1 || workerDensity > 20)
            {
                 throw new RobotSafetyException("Error: Worker density must be 1-20");
            }
               
            double machineRiskFactor;

            // Validations
            switch (machineryState)
            {
                case "Worn":
                    machineRiskFactor = 1.3;
                    break;

                case "Faulty":
                    machineRiskFactor = 2.0;
                    break;

                case "Critical":
                    machineRiskFactor = 3.0;
                    break;

                default:
                    throw new RobotSafetyException("Error: Unsupported machinery state");
            }

            // Required formula
            double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
    
            return hazardRisk;
        }
    }

    /// <summary>
    /// Program entry point class.
    /// </summary>
    public class Program2
    {
        public static void Main(string[] args)
        {
            // Create auditor object responsible for risk calculations
            RobotHazardAuditor auditor = new RobotHazardAuditor();

            try
            {
                // Prompt user for robot arm precision input
                Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
                double armPrecision = double.Parse(Console.ReadLine());

                // Prompt user for worker density input
                Console.WriteLine("Enter Worker Density (1 - 20):");
                int workerDensity = int.Parse(Console.ReadLine());

                // Prompt user for machinery condition input
                Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
                string machineryState = Console.ReadLine();

                // Calculate hazard risk score using provided inputs
                double risk = auditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

                // Display calculated risk score
                Console.WriteLine($"Robot Hazard Risk Score: {risk}");
            }
            catch (RobotSafetyException ex)
            {
                // Display validation error returned from auditor
                Console.WriteLine(ex.Message);
            }
        }
    }
}
