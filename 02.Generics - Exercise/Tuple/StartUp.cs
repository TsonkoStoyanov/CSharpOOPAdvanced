using System;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfoInput = Console.ReadLine().Split();
            CustomTuple<string, string, string> personInfo = new CustomTuple<string, string, string>(personInfoInput[0] + " " + personInfoInput[1], personInfoInput[2], personInfoInput[3]);
            Console.WriteLine(personInfo);


            string[] beerInfoInput = Console.ReadLine().Split();
            bool isDrunk = beerInfoInput[2] == "drunk";

            CustomTuple<string, int, bool> beerInfo = new CustomTuple<string, int, bool>(beerInfoInput[0], int.Parse(beerInfoInput[1]), isDrunk);
            Console.WriteLine(beerInfo);


            string[] lastInput = Console.ReadLine().Split();
            CustomTuple<string, double, string> lastInfo = new CustomTuple<string, double, string>(lastInput[0], double.Parse(lastInput[1]), lastInput[2]);
            Console.WriteLine(lastInfo);
        }
    }
}
