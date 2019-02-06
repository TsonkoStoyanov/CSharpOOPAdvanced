using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> colections;

        public CustomStack()
        {
            colections = new List<T>();
        }

        public void Pop()
        {
            if (colections.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                colections.RemoveAt(colections.Count - 1);

            }
        }

        public void Push(IEnumerable<T> elements)
        {
            colections.AddRange(elements);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < colections.Count; i++)
            {
                yield return colections[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}