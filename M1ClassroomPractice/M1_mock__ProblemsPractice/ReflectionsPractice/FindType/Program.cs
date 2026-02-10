using System;
using System.Linq;
using System.Reflection;

namespace ReflectionsPractice
{
    /// <summary>
    /// Lists non-public instance methods declared
    /// only in the given type using Reflection.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Read full type name from input
            string typeName = Console.ReadLine();

            // Try to locate the type in loaded assemblies
            Type targetType = Type.GetType(typeName);

            // If not found, search manually in assemblies
            if (targetType == null)
            {
                targetType = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Select(a => a.GetType(typeName))
                    .FirstOrDefault(t => t != null);
            }

            // Output if type not found
            if (targetType == null)
            {
                Console.WriteLine("TYPE_NOT_FOUND");
                return;
            }

            // Get methods declared ONLY in this class
            var methods = targetType
                .GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly)
                // Exclude property/event special methods
                .Where(m => !m.IsSpecialName)
                // Sort method names
                .Select(m => m.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            // Output if no methods found
            if (methods.Count == 0)
            {
                Console.WriteLine("NO_METHODS");
                return;
            }

            // Print method names
            foreach (var method in methods)
            {
                Console.WriteLine(method);
            }
        }
    }
}
