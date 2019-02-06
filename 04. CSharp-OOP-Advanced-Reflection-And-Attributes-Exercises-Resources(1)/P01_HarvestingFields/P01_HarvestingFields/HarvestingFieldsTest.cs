using System.Linq;
using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic
                                                    | BindingFlags.Instance
                                                    | BindingFlags.Public
                                                    | BindingFlags.FlattenHierarchy);

                FieldInfo[] fieldsToPrint = fields.Where(f => f.Attributes.ToString().ToLower().Replace("family", "protected") == input).ToArray();

                if (input=="all")
                {
                    foreach (var field in fields)
                    {
                        Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                    }  
                    continue;
                }

                foreach (var field in fieldsToPrint)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                }
            }

        }
    }
}
