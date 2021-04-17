using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CustomThreeuple
{
    public class CustomTuple<T, T2, T3>
        where T3: IConvertible
    {
        public CustomTuple(T itemOne, T2 itemTwo, T3 itemThree)
        {
            ItemOne = itemOne;

            ItemTwo = itemTwo;

            ItemThree = itemThree;
        }
        public T ItemOne { get; set; }

        public T2 ItemTwo { get; set; }

        public T3 ItemThree { get; set; }

        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo} -> {ItemThree}";
        }

    }
}
