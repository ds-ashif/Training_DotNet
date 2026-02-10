using System;
using System.Reflection;

namespace EmployeeType
{
    class Program
    {
        static void Main()
        {
            // Employee emp = new Employee(101, "Arun", 45000);

            // Type t1 = typeof(Employee);     // compile-time
            // Type t2 = emp.GetType();        // runtime

            // // Type t1 = typeof(Employee);
            // // Type t2 = emp.GetType();

            // Console.WriteLine(t1.FullName);
            // Console.WriteLine(t2.FullName);
            // Console.WriteLine(t1 == t2);    // True


            //-----------------------------Example: List all public methods------------------------------------

            // Type t = typeof(Employee);

            // //By default, GetMethods() includes inherited public methods (like ToString()). Use BindingFlags to fine-tune.
            // var methods = t.GetMethods();      // public instance + inherited public methods

            // foreach(var m in methods)
            // {
            //     Console.WriteLine($"{m.ReturnType.Name} {m.Name}");
            // }


            //-------------------------Example: List properties and their types-------------------------------
            // Type t = typeof(Employee);
            // foreach(PropertyInfo p in t.GetProperties())
            // {
            //     Console.WriteLine($"{p.PropertyType.Name} {p.Name} (CanRead={p.CanRead}, CanWrite={p.CanWrite})");
            // }

            //Example: List fields (public only by default)
            // Type t = typeof(Employee);
            // foreach(FieldInfo f in t.GetFields())
            // {
            //     Console.WriteLine($"{f.FieldType.Name} {f.Name}");
            // }

            //----------------------Example: Get private field using BindingFlags------------------------------
            // Employee emp = new Employee(101,"Ashif",50000);
            // Type t = typeof(Employee);

            //private instance field "secretCode"
            // FieldInfo? f = t.GetField("secretCode", BindingFlags.Instance | BindingFlags.NonPublic);
            // if (f == null)
            // {
            //     Console.WriteLine("Field not found");
            //     return;
            // }

            // object? value = f.GetValue(emp);
            // Console.WriteLine("Secret Code = " + value);

            /**
            Warning: private access
            Accessing private members can break encapsulation and may fail in restricted environments. 
            Use this only for diagnostics/tools or controlled frameworks.**/

            //---------------------------------Create Objects Dynamically------------------------------------------------------------
            /**
            Sometimes you only know the class name at runtime (plugins, configs, user selection). 
            You can create instances using Activator.CreateInstance.
            **/

            // Type t = typeof(Employee);

            // object? obj = Activator.CreateInstance(t);

            // Employee emp = (Employee)obj!;
            // emp.Id = 201;
            // emp.Name = "Divya";

            // Console.WriteLine($"{emp.Id} - {emp.Name}");

            //------------Example: Create instance using constructor parameters---------------------------------

            // Type t = typeof(Employee);

            // object? obj = Activator.CreateInstance(t,301,"Ashif",5500m);

            // EmployeeType emp = (Employee)obj!;

            // Console.WriteLine($"{emp.Id} - {emp.Name} - {emp.Salary}");

            //If no matching constructor exists, you will get MissingMethodException.


            //-------------------------Invoke Methods Dynamically-----------------------------------------
            //After you find a method using reflection, you can invoke it using MethodInfo.Invoke.


            //Example: Call public method GiveRaise()

            // Employee emp = new Employee(101, "Arun", 45000m);

            // Type t = emp.GetType();

            // MethodInfo? m = t.GetMethod("GiveRaise");

            // m!.Invoke(emp, new object[] {500m});

            // Console.WriteLine(emp.Salary);


            //------------------Example: Call private method GetSecretCode()---------------------
            Employee emp = new Employee(101, "Arun", 45000m);
            Type t = emp.GetType();

            MethodInfo? m = t.GetMethod("GetSecretCode", BindingFlags.Instance | BindingFlags.NonPublic);

            object? result = m!.Invoke(emp,null);
            Console.WriteLine("Private method result = " + result);

            /**
            Note: parameters are object[]
            Invoke always takes object?[]? parameters. Value types (like int, decimal) are boxed into objects.
            **/

            //--------------Get/Set Properties & Fields--------------------
            //Example: Set and Get public property (Name)

            // Employee emp = new Employee();

            // Type t = typeof(Employee);
            // PropertyInfo? p = t.GetProperty("Name");

            // p!.SetValue(emp, "Anita");
            // Console.WriteLine(p.GetValue(emp)); // Anita

            //Example: Read Salary (private setter)

            // var emp = new Employee(101, "Arun", 45000m);

            // var p = typeof(Employee).GetProperty("Salary");
            // Console.WriteLine(p!.GetValue(emp)); // 45000

            //------------------------- Set a private field using reflection----------------

               var emp = new Employee(101, "Arun", 45000m);

            var f = typeof(Employee).GetField("secretCode",
            BindingFlags.Instance | BindingFlags.NonPublic);

            f!.SetValue(emp, "NEW-SECRET");

            // verify by calling private method (for demo)
            var m = typeof(Employee).GetMethod("GetSecretCode",BindingFlags.Instance | BindingFlags.NonPublic);

            Console.WriteLine(m!.Invoke(emp, null)); // NEW-SECRET
            

        

            
            



        }
    }
}