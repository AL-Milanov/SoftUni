using System;
using System.Collections.Generic;
using System.Text;

namespace _07.TupleClass
{
    public class CustomTuple <T, T1>
    {
        private T itemOne;
        private T1 itemTwo;

        public CustomTuple(T itemOne, T1 itemTwo)
        {
            this.itemOne = itemOne;

            this.itemTwo = itemTwo;
        }

        public override string ToString()
        {
            return $"{itemOne} -> {itemTwo}";     
        }
    }
}
