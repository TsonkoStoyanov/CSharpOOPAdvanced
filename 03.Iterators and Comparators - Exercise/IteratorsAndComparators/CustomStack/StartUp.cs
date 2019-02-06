using System;
using System.Linq;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<string> customStack = new CustomStack<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];

                switch (command)
                {
                    case "Push":
                        var elements = inputArgs.Skip(1);
                        customStack.Push(elements);
                        break;
                    case "Pop":
                        customStack.Pop();
                        break;
                }
            }

            if (customStack.Count() != 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, customStack));
                Console.WriteLine(string.Join(Environment.NewLine, customStack));

            }

        }

    }
}
