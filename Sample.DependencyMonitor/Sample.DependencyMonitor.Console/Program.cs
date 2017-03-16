using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sample.DependencyMonitor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllPath = @"D:\BOA\client\bin\BOA.EOD.CoreBanking.Customer.dll";

            Assembly assembly = Assembly.LoadFrom(dllPath);
            string namespacee = assembly.GetName().Name;
            List<string> classList = assembly.GetTypes().Where(x => x.IsClass).Select(x => x.FullName).Distinct().ToList();
            if (classList != null && classList.Count != 0)
            {
                List<string> methodList = assembly.GetTypes().Where(x => x.IsClass && x.FullName == classList.FirstOrDefault()).FirstOrDefault().GetMethods().Select(x => x.Name).Distinct().ToList();
            }
        }
    }
}
