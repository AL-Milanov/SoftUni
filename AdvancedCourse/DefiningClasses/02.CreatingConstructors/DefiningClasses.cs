using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person pesho = new Person();

            Console.WriteLine(pesho.Name + " - " + pesho.Age);
        }
    }
}
