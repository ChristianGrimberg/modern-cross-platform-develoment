using System.Linq;
using System.Reflection;
namespace _02_01_basics;
class Program
{
    static void Main(string[] args)
    {
        // Declare some unused variables using types an additional assemblies
#pragma warning disable CS0168 // Variables declared but never used
        System.Data.DataSet ds;
        System.Net.Http.HttpClient client;
#pragma warning restore CS0168

#pragma warning disable CS8602 // Dereference of a possibly null reference
        // Loop through the assemblies that this app reference
        foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
#pragma warning restore CS8602
        {
            // Load the assembly so we can read its details
            var a = Assembly.Load(new AssemblyName(r.FullName));

            // Declare a variable to count the number of methods
            int methodCount = 0;

            // Loop through all the types in the assembly
            foreach (var t in a.DefinedTypes)
            {
                // Add up the counts of methods
                methodCount += t.GetMethods().Count();
            }

            // Output the count of types and their methods
            Console.WriteLine(
                "{0:N0} types with {1:N0} methods in {2} assembly",
                arg0: a.DefinedTypes.Count(),
                arg1: methodCount,
                arg2: r.Name
            );
        }
    }
}
