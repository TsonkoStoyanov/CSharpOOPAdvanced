using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            string[] elements = Console.ReadLine().Split().Skip(1).ToArray();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {

                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;

                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;

                    case "Print":
                        try
                        {
                            listyIterator.Print();

                        }
                        catch (InvalidOperationException ie)
                        {
                            Console.WriteLine(ie.Message);
                        }
                        break;

                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;

                }
            }
        }
    }
}
