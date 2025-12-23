// using System;

// namespace HelloWorldApp
// {
//     class Program3
//     {
//         static void Main(string[] args)
//         {
//             Person person = new Person { Id = 1, Name = "Amit", Age = 21 };

//             Person man = new Man()
//             {
//                 Id = 2,
//                 Name = "Aarav",
//                 Age = 25,
//                 Playing = "Football"
//             };

//             Person woman = new Woman()
//             {
//                 Id = 3,
//                 Name = "Anita",
//                 Age = 23,
//                 PlayingAndManagement = "Cricket and Team Management"
//             };

//             Person child = new Child()
//             {
//                 Id = 4,
//                 Name = "Anjali",
//                 Age = 10,
//                 Studies = "Primary School Studies"
//             };

//             GetDetails(person);
//             GetDetails(man);
//             GetDetails(woman);
//             GetDetails(child);
//         }

//         public static void GetDetails(Person input)
//         {
//             Console.WriteLine($"Id: {input.Id}, Name: {input.Name}, Age: {input.Age}");

//             if (input is Man m)
//                 Console.WriteLine($"  Playing: {m.Playing}");
//             else if (input is Woman w)
//                 Console.WriteLine($"  Playing & Management: {w.PlayingAndManagement}");
//             else if (input is Child c)
//                 Console.WriteLine($"  Studies: {c.Studies}");

//             Console.WriteLine();
//         }
//     }
// }
