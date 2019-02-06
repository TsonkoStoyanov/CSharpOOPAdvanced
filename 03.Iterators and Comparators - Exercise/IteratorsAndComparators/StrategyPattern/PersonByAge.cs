using System.Collections.Generic;

namespace StrategyPattern
{
    internal class PersonByAge : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return first.Age.CompareTo(second.Age);
        }
    }
}