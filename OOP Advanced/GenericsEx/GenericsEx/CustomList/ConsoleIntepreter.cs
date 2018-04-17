using System;


class ConsoleIntepreter
{
    static void Main(string[] args)
    {
        var list = new CustomList<string>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var inputData = input.Split(' ');
            var command = inputData[0];

            switch (command)
            {
                case "Add":
                    list.Add(inputData[1]);
                    break;
                case "Remove":
                    list.Remove(int.Parse(inputData[1]));
                    break;
                case "Contains":
                    Console.WriteLine(list.Contains(inputData[1]));
                    break;
                case "Swap":
                    list.Swap(int.Parse(inputData[1]), int.Parse(inputData[2]));
                    break;
                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(inputData[1]));
                    break;
                case "Min":
                    Console.WriteLine(list.Min());
                    break;
                case "Max":
                    Console.WriteLine(list.Max());
                    break;
                case "Sort":
                    list = Sorter.Sort(list);
                    break;
                case "Print":
                    var printResult = list.ToString();
                    if (!string.IsNullOrWhiteSpace(printResult))
                    {
                        Console.WriteLine(printResult);
                    }
                    break;
            }
        }
    }
}

