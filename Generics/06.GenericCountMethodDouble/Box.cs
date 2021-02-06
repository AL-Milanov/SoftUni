using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T>
        where  T: IComparable
    {
        private List<T> data = new List<T>();

        public Box(List<T> value)
        {
            data = value;
        }

        public int Count => data.Count;

        public int CustomCompare(T value)
        {
            int counter = 0;

            foreach (var item in data)
            {
                if (item.CompareTo(value) > 0)
                {
                    counter++;
                }
            }
            
            return counter;

        }

        public void Swap(List<T> list, int firstIndex, int secondIndex)
        {
            if (IsValid(firstIndex, list) && IsValid(secondIndex, list))
            {
                T firstIndexData = list[firstIndex];
                list[firstIndex] = list[secondIndex];
                list[secondIndex] = firstIndexData;
                this.data = list;
            }
        }

        private bool IsValid(int index, List<T> data)
        {
            return index >= 0 && index < data.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var text in data)
            {
               sb.Append($"{text.GetType()}: {text}" + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
