using System;
using System.Collections.Generic;


namespace PharmacyMedicineInventorySystem
{
     // ---------------- MEDICINE ----------------
     // Represents medicine entity stored in the inventory

    public class Medicine
    {
        // Unique medicine ID
        public string Id { get; set; }

         // Medicine name
        public string Name { get; set; }

        // Medicine price
        public int Price { get; set; }

         // Expiry year of medicine
        public int ExpiryYear { get; set; }

    }

    // ---------------- EXCEPTIONS: Used for validation and business rule violations ----------------
    public class InvalidPriceException : Exception{}
    public class DuplicateMedicineException: Exception{}
    public class InvalidExpiryYearException : Exception{}
    public class MedicineNotFoundException : Exception{}


    // ---------------- UTILITY: Contains operations for medicine management ----------------
    class MedicineUtility
    {
        //private dictionary to store medicines
        private static SortedDictionary<int, List<Medicine>> store = new SortedDictionary<int, List<Medicine>>();

        // method to Add medicines after validation checks

        public void AddMedicine(Medicine medicine)
        {
            // Price validation
            if(medicine.Price<=0) throw new InvalidPriceException();

            // Expiry year validation
            if(medicine.ExpiryYear < DateTime.Now.Year) throw new InvalidExpiryYearException();

            //duplicate id check
            foreach(var list in store.Values)
            {
                foreach(var med in list)
                {
                    if(med.Id == medicine.Id) throw new DuplicateMedicineException();
                }
            }

            // Create list if year not present
            if (!store.ContainsKey(medicine.ExpiryYear))
            {
                store[medicine.ExpiryYear] = new List<Medicine>();
            }
            
            // Add medicine to list
            store[medicine.ExpiryYear].Add(medicine);
            

        }

        //Returns complete medicine store
        public SortedDictionary<int, List<Medicine>> GetAllMedicines()
        {
            if(store.Count==0) Console.WriteLine("No medicine is added yet. Please add!");
            return store;
        }

        //Updates price of medicine using ID
        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if (newPrice <= 0) throw new InvalidPriceException();

            foreach (var list in store.Values)
            {
                foreach(var med in list)
                {
                    if(med.Id == id)
                    {
                        med.Price = newPrice;
                        return;
                    }
                }
            }

            throw new MedicineNotFoundException();
        }

    }


// ---------------- PROGRAM : Provides menu driven interface ----------------
    class Program
    {
        static void Main()
        {
            MedicineUtility utility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1 Display");
                Console.WriteLine("2 Update Price");
                Console.WriteLine("3 Add Medicine");
                Console.WriteLine("4 Exit");

                int choice = int.Parse(Console.ReadLine());

                // ---------------- Display Medicines ----------------
                if(choice == 1)
                {
                    var data = utility.GetAllMedicines();

                    foreach(var year in data)
                    {
                        foreach(var med in year.Value)
                        {
                            Console.WriteLine($"Details: {med.Id} {med.Name} {med.Price} {med.ExpiryYear}");
                        }
                    }
                }
                 // ---------------- Update Price ----------------
                else if(choice == 2)
                {
                    Console.WriteLine("\nEnter id, new price (<id> <newprice>):");
                    string[] input = Console.ReadLine().Split(' ');
                    utility.UpdateMedicinePrice(input[0],int.Parse(input[1]));
                    Console.WriteLine("Updation Successfull.");
                }
                // ---------------- Add Medicine ----------------
                else if(choice == 3)
                {
                    Console.WriteLine("\nEnter medicine object data (<id> <name> <price> <expiryyear>):");
                    string[] input = Console.ReadLine().Split(' ');
                    Medicine med = new Medicine
                    {
                        Id=input[0],
                        Name = input[1],
                        Price = int.Parse(input[2]),
                        ExpiryYear = int.Parse(input[3])

                    };

                    utility.AddMedicine(med);

                    Console.WriteLine($"{med.Name} Medicine added!");
                }
                // ---------------- Exit Program ----------------
                else if(choice == 4)
                {
                    break;
                }
            }
        }
    }
}