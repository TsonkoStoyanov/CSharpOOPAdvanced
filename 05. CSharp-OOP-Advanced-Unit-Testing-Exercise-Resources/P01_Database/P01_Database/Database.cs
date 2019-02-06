using System;
using System.Linq;

namespace P01_Database
{
    public class Database
    {
        private const int Capacity = 16;
        private int[] elemetns;
        private int index;

        public Database()
        {
            this.elemetns = new int[Capacity];
            this.index = -1;
        }

        public Database(int[] values)
        : this()
        {
            InitializeArr(values);
        }

        public void Add(int value)
        {
            if (index++ > Capacity)
            {
                index--;
                throw new InvalidOperationException("Database is full!");
            }

            this.elemetns[index] = value;
        }

        public void Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.elemetns[index] = 0;
        }

        public int[] Fetch()
        {

            return this.elemetns.Take(this.index + 1).ToArray();
        }


        private void InitializeArr(int[] values)
        {
            if (values.Length > Capacity)
            {
                throw new InvalidOperationException("Invalid length!");
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.elemetns[i] = values[i];
            }

            this.index = values.Length - 1;
        }


    }
}