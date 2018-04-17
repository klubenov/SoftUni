using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxIntegerType = typeof(BlackBoxInteger);
            var blackBoxConstructor = blackBoxIntegerType.GetConstructor(BindingFlags.Instance|BindingFlags.NonPublic,null,new Type[0],null);
            BlackBoxInteger blackBoxInteger = (BlackBoxInteger) blackBoxConstructor.Invoke(new object[] { });

            var blackBoxMethods = blackBoxIntegerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var blackBoxFields = blackBoxIntegerType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var blackBoxInnerValueField = blackBoxFields.FirstOrDefault(f => f.Name == "innerValue");

            string input;

            while ((input=Console.ReadLine())!="END")
            {
                var inputData = input.Split("_");
                var command = inputData[0];
                var value = int.Parse(inputData[1]);

                InvokeMethod(command, value, blackBoxInteger, blackBoxInnerValueField, blackBoxMethods);
            }
        }

        public static void InvokeMethod(string command, int value, BlackBoxInteger blackBoxInteger,FieldInfo blackBoxInnerValueField,MethodInfo[] blackBoxMethods)
        {
            blackBoxMethods.First(m => m.Name == command).Invoke(blackBoxInteger, new object[] { value });
            Console.WriteLine(blackBoxInnerValueField.GetValue(blackBoxInteger));
        }
    }
}
