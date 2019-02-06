﻿namespace Tuple
{
    public class CustomTuple<T1, T2, T3>
    {
        private readonly T1 item1;
        private readonly T2 item2;
        private readonly T3 item3;

        public CustomTuple(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}