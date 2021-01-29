using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstStudent = new Person();
            Person secondStudent = new Person();
            Person thirdStudent = new Person();

            firstStudent.Name = "Pesho";
            firstStudent.Age = 20;

            secondStudent.Name = "Gosho";
            secondStudent.Age = 18;

            thirdStudent.Name = "Stamat";
            thirdStudent.Age = 43;

            Console.WriteLine(firstStudent.Name + "-" + firstStudent.Age);
        }
    }
}
