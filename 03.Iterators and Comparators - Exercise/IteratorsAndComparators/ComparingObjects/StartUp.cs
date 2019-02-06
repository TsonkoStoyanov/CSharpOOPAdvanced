using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            int equalPeople = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];

                int age = int.Parse(inputArgs[1]);

                string town = inputArgs[2];


                Person person = new Person(name, age, town);
                persons.Add(person);
            }

            int index = int.Parse(Console.ReadLine());

            Person personToCompare = persons[index - 1];

            foreach (var person in persons)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine($"{equalPeople} {persons.Count - equalPeople} {persons.Count}");

            }
            else
            {
                Console.WriteLine("No matches");

            }
        }
    }
}
