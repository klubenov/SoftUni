 using System.Linq;

namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input;
            Type classType = typeof(HarvestingFields);

            while ((input=Console.ReadLine())!="HARVEST")
            {
                switch (input)
                {
                    case "private":
                        var privateFields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f=>f.IsPrivate).ToArray();
                        PrintFields(privateFields);
                        break;
                    case "public":
                        var publicFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                        PrintFields(publicFields);
                        break;
                    case "protected":
                        var protectedFields =
                            classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f=> f.IsFamily).ToArray();
                        PrintFields(protectedFields);
                        break;
                    case "all":
                        var allFields = classType.GetFields(BindingFlags.NonPublic | 
                            BindingFlags.Public | BindingFlags.Instance);
                        PrintFields(allFields);
                        break;

                }
            }
        }

        private static void PrintFields(FieldInfo[] fields)
        {
            foreach (var field in fields)
            {
                string modifier = "";

                if (field.IsFamily)
                {
                    modifier = "protected";
                }
                else if (field.IsPrivate)
                {
                    modifier = "private";
                }
                else if (field.IsPublic)
                {
                    modifier = "public";
                }

                Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
