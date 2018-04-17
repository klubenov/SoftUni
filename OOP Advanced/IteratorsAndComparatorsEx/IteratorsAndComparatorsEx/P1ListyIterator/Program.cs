using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var createCommand = Console.ReadLine().Split(' ');
            var listyIterator = new ListyIterator<string>(createCommand.Skip(1).ToArray());

            string input;

            while ((input=Console.ReadLine())!="END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(listyIterator.Print());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        var printSb = new StringBuilder();
                        foreach (var item in listyIterator)
                        {
                            printSb.Append(item + " ");
                        }
                        Console.WriteLine(printSb.ToString().TrimEnd());
                        break;
                } 
            }
            Environment.Exit(0);
        }
    }
}
