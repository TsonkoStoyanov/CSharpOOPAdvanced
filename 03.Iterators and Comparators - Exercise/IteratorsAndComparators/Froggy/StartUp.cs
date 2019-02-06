using System;
using System.Linq;

namespace Froggy
{
    class StartUp
    {
        static void Main()
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
