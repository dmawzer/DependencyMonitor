using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sample.DependencyMonitor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllPath = @"D:\blabla.dll";

            Assembly assembly = Assembly.LoadFrom(dllPath);
            string namespacee = assembly.GetName().Name;
            System.Console.WriteLine("- Namespace: {0}", namespacee);

            List<string> classList = assembly.GetTypes()
                                                .Where(x => x.IsClass)
                                                .Select(x => x.FullName)
                                                .Distinct()
                                                .ToList();

            foreach (var item in classList)
            {
                System.Console.WriteLine("      -> ClassName: {0}", item);

                List<string> methodList = assembly.GetTypes()
                                                    .Where(x => x.IsClass && x.FullName == item)
                                                    .FirstOrDefault()
                                                    .GetMethods()
                                                    .Select(x => x.Name)
                                                    .Distinct()
                                                    .ToList();

                foreach (var method in methodList)
                {
                    System.Console.WriteLine("          => MethodName: {0}", method);
                }
            }

            System.Console.ReadLine();
        }
    }
}
