using CollectionOfHierarchy.Contracts;
using System;
using System.Collections.Generic;

namespace CollectionOfHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeOperations = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            AddToCollection(data, addCollection);
            AddToCollection(data, addRemoveCollection);
            AddToCollection(data, myList);

            RemoveFromCollection(removeOperations, addRemoveCollection);
            RemoveFromCollection(removeOperations, myList);
        }

        private static void RemoveFromCollection(int removeOperations, IRemove collection)
        {
            string res = string.Empty;

            for (int i = 0; i < removeOperations; i++)
            {
                if (i == removeOperations - 1)
                {
                    res += collection.Remove();
                    break;
                }
                res += collection.Remove() + " ";
            }

            Console.WriteLine(res);
        }

        private static void AddToCollection(string[] data, IAdd collection)
        {
            string res = string.Empty;

            for (int i = 0; i < data.Length; i++)
            {
                if (i == data.Length - 1)
                {
                    res += collection.Add(data[i]);
                    break;
                }
                res += collection.Add(data[i]) + " ";
            }
            Console.WriteLine(res);
        }
    }
}
