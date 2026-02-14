//Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False; Command Timeout = 30


using Microsoft.Data.SqlClient;
using System.Data;

namespace FirstAdoLearning
{


    class Program
    {
        
        static void Main()
        {
            // string cs = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TrainingDB; Integrated Security = True; TrustServerCertificate=True";
            // string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

            // using (var con = new SqlConnection(cs))
            // using (var cmd = new SqlCommand(sql, con))
            // {
            //     con.Open();

            //     using (var reader = cmd.ExecuteReader())
            //     {
            //         Console.WriteLine("Reading employees...\n");

            //         while (reader.Read())
            //         {
            //             int id = reader.GetInt32(0);
            //             string name = reader.GetString(1);
            //             string dept = reader.GetString(2);
            //             decimal salary = reader.GetDecimal(3);

            //             Console.WriteLine($"{id} | {name} | {dept} | {salary}");
            //         }
            //         Console.WriteLine("\nDone.");
            //         Console.ReadLine();
            //     }
            // }


            // string cs = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TrainingDB; Integrated Security = True; TrustServerCertificate=True";
			// //string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

			// Console.Write("Enter Department (e.g., IT): ");
			// string dept = Console.ReadLine() ?? "";

			// //@ is used to ignore escape sequences in the string, so we can write the SQL query in a more readable format without worrying about special characters.
			// string sql = @"SELECT EmployeeId, FullName, Salary
            //    FROM dbo.Employees
            //    WHERE Department = @dept                  
            //    ORDER BY Salary DESC";    //the above @ is used to define a parameter in the SQL query, which will be replaced with the actual value of the 'dept' variable when the query is executed. This helps prevent SQL injection attacks and allows for safer and more efficient query execution.


			// using var con = new SqlConnection(cs);
			// using var cmd = new SqlCommand(sql, con);

			// // ✅ Add parameter
			// cmd.Parameters.AddWithValue("@dept", dept);
			// con.Open();
			// using var r = cmd.ExecuteReader();
			// while (r.Read())
			// {
			// 	Console.WriteLine($"{r["EmployeeId"]} | {r["FullName"]} | {r["Salary"]}");
			// }



            //disconnected architecture

        string cs = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TrainingDB; Integrated Security = True; TrustServerCertificate=True";
        string sql = "SELECT EmployeeId, FullName, Department FROM dbo.Employees";

        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }
        ds.WriteXml("TestData");
        }
    }
}