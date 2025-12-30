// using System;
// using System.Runtime.CompilerServices;
// namespace HelloWorldApp
// {
//     class HighSchoolStudents
//     {
//         public int id;
//         public string Name;

//         public double Attendance;

//         public double CGPA;
//         public string School;


//         public HighSchoolStudents()
//         {
//             Console.WriteLine("Enter student details: id, name, attendance, cgpa, school name");
//             id=Convert.ToInt32(Console.ReadLine());
//             Name=Console.ReadLine();
//             Attendance=Convert.ToDouble(Console.ReadLine());
//             CGPA=Convert.ToDouble(Console.ReadLine());
//             School=Console.ReadLine();

//         }

//         public getHighSchoolStudentSetails()
//         {
//             Console.WriteLine("----------High School Students Details ---------------");
//             Console.WriteLine();
//             Console.WriteLine($"Id:  {ID}");
//             Console.WriteLine($"Name:  {Name}");
//             Console.WriteLine($"Attendance:  {Attendance}");
//             Console.WriteLine($"CGPA:  {CGPA}");
//         }

//     }

//     class UGStudents:HighSchoolStudents
//     {
        
//         public string Department;

//         public string University;


//         public HighSchoolStudents()
//         {
//             Console.WriteLine("Enter student details: id, name, department attendance, cgpa, university");
//             id=Convert.ToInt32(Console.ReadLine());
//             Name=Console.ReadLine();
//             Attendance=Convert.ToDouble(Console.ReadLine());
//             CGPA=Convert.ToDouble(Console.ReadLine());
//             University=Console.ReadLine();

//         }

//         public getHighSchoolStudentSetails()
//         {
//             Console.WriteLine("---------- UG Students Details ---------------");
//             Console.WriteLine();
            
//             Console.WriteLine($"Department: {Department}");
//             Console.WriteLine($"University: {University}");
//         }

//     }

// class PgStudents:HighSchoolStudents
//     {
//         public string ugDegree;


//         public HighSchoolStudents()
//         {
//             Console.WriteLine("Enter student details: id, name, attendance, cgpa");
//             id=Convert.ToInt32(Console.ReadLine());
//             Name=Console.ReadLine();
//             Attendance=Convert.ToDouble(Console.ReadLine());
//             CGPA=Convert.ToDouble(Console.ReadLine());

//         }

//         public getHighSchoolStudentSetails()
//         {
//             Console.WriteLine("----------High School Students Details ---------------");
//             Console.WriteLine();
//             Console.WriteLine($"Id:  {ID}");
//             Console.WriteLine($"Name:  {Name}");
//             Console.WriteLine($"Attendance:  {Attendance}");
//             Console.WriteLine($"CGPA:  {CGPA}");
//         }

//     }

// }