using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private T[] colections;
        private int index;

        public ListyIterator(T[] colections)
        {
            this.colections = colections;
            this.index = 0;
        }


        public bool Move()
        {
            if (index < this.colections.Length - 1)
            {
                index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (colections.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(colections[index]);
        }


        public bool HasNext()
        {
            return index < this.colections.Length - 1 ? true : false;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < colections.Length; i++)
            {
                yield return colections[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        internal void PrintAll()
        {
            Console.WriteLine(string.Join(" ", colections));
        }
    }
}