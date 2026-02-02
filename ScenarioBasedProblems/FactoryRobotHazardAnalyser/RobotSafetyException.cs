// using System;
// using System.Collections.Generic;
// using System.Text;

// namespace FactoryRobotHazardAnalyser
// {
//     /// <summary>
//     /// Custom exception used for robot safety validation errors.
//     /// </summary>
//     public class RobotSafetyException:Exception
//     {
//         /// <summary>
//         /// Initializes a new instance of the RobotSafetyException class.
//         /// </summary>
//         /// <param name="message">Error message describing the validation failure.</param>
//         /// 

//         public RobotSafetyException(string message) : base(message)
//         {

//         }

//     }

//     /// <summary>
//     /// Provides functionality to audit and calculate robot hazard risk.
//     /// </summary>
//     /// 

//     public class RobotHazardAuditor
//     {
//         /// <summary>
//         /// Calculates and returns the hazard risk score for a factory robot.
//         /// </summary>
//         /// <param name="armPrecision">
//         /// Precision of the robot arm (range: 0.0 to 1.0).
//         /// </param>
//         /// <param name="workerDensity">
//         /// Number of workers near the robot (range: 1 to 20).
//         /// </param>
//         /// <param name="machineryState">
//         /// Current state of machinery ("Worn", "Faulty", or "Critical").
//         /// Case-sensitive.
//         /// </param>
//         /// <returns>
//         /// Calculated hazard risk score as a double.
//         /// </returns>
//         /// <exception cref="RobotSafetyException">
//         /// Thrown when input validation fails.
//         /// </exception>
//         public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
//         {
//             // Validate arm precision
//             if (armPrecision < 0.0 || armPrecision > 1.0)
//             {
//                 throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0.");
//             }

//             // Validate worker density
//             if (workerDensity < 1 || workerDensity > 20)
//             {
//                 throw new RobotSafetyException("Error: Worker density must be 1-20.");
//             }

//             // Determine machinery risk factor
//             double machineryFactor;

//             switch (machineryState)
//             {
//                 case "Worn":
//                     machineryFactor = 1.2;
//                     break;

//                 case "Faulty":
//                     machineryFactor = 1.5;
//                     break;

//                 case "Critical":
//                     machineryFactor = 2.0;
//                     break;

//                 default:
//                     throw new RobotSafetyException("Error: Unsupported machinery state");
//             }

//             // Hazard risk calculation
//             double hazardRisk = (1 - armPrecision) * workerDensity * machineryFactor;

//             return hazardRisk;
//         }
//     }


// }
