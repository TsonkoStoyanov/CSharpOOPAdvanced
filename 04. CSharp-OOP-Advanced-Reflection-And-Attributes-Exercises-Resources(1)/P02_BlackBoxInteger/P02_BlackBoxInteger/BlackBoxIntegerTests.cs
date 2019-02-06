
using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            string input = String.Empty;

            var box = (BlackBoxInteger)Activator.CreateInstance(type, true);

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split("_");

                string command = inputArgs[0];

                int value = int.Parse(inputArgs[1]);

                MethodInfo methods = type
                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).First(m => m.Name == command);

                methods.Invoke(box, new object[] {value});

                var result = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.Name == "innerValue").GetValue(box);

                Console.WriteLine(result);
            }
        }
    }
}
