using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> personsByName = new SortedSet<Person>(new PersonsByName());
            SortedSet<Person> personsByAge = new SortedSet<Person>(new PersonByAge());

            while (n-- > 0)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string name = inputArgs[0];

                int age = int.Parse(inputArgs[1]);

                Person person = new Person(name, age);

                personsByName.Add(person);
                personsByAge.Add(person);

            }

            Console.WriteLine(string.Join(Environment.NewLine, personsByName));
            Console.WriteLine(string.Join(Environment.NewLine, personsByAge));

        }
    }
}
