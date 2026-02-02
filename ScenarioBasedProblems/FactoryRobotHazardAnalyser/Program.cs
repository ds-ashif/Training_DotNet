// namespace FactoryRobotHazardAnalyser
// {
//     public class Program
//     {

//         public static void Main(string[] args)
//         {
//             RobotHazardAuditor auditor = new RobotHazardAuditor();

//             try
//             {
//                 double riskScore=auditor.CalculateHazardRisk(0.95, 10, "Operational");
//                 Console.WriteLine($"Hazard Risk Score: {riskScore:F2}");
//             }
//             catch(RobotSafetyException ex)
//             {
//                 Console.WriteLine($"Safety Exception: {ex.Message}");
//             }
//         }
//     }
// }
