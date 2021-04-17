using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);

                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (input == "Tomcat")
                {
                    Tomcat tomcat = new Tomcat(name, age);

                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
                else if (input == "Kitten")
                {
                    Kitten kitten = new Kitten(name, age);

                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);

                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);

                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }


                input = Console.ReadLine();
            }
        }

    }
}

