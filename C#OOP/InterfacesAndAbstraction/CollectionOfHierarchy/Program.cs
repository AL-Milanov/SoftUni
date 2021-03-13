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
           
            for (int i = 0; i < removeOperations; i++)
            {
                Console.Write(collection.Remove() + " ");
            }
            Console.WriteLine();
        }

        private static void AddToCollection(string[] data, IAdd collection)
        {
            
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(collection.Add(data[i]) + " ");
            }
            Console.WriteLine();
        }
    }
}
