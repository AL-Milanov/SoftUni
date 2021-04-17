using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "End")
                {
                    break;
                }

                string[] animalData = animalType.Split();

                Animal animal = GetAnimal(animalData);
                animals.Add(animal);

                Console.WriteLine(animal.ProduceSound());

                string[] foodData = Console.ReadLine().Split();
                Food food = GetFood(foodData);
                
                try
                {
                    animal.Eating(food);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food GetFood(string[] foodData)
        {
            string type = foodData[0];
            int quantity = int.Parse(foodData[1]);

            Food food = null;

            if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal GetAnimal(string[] animalData)
        {
            string type = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);

            Animal animal = null;

            if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalData[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livinRegion = animalData[3];
                animal = new Mouse(name, weight, livinRegion);
            }
            else if (type == nameof(Dog))
            {
                string livinRegion = animalData[3];
                animal = new Dog(name, weight, livinRegion);
            }
            else if (type == nameof(Cat))
            {
                string livinRegion = animalData[3];
                string breed = animalData[4];
                animal = new Cat(name, weight, livinRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livinRegion = animalData[3];
                string breed = animalData[4];
                animal = new Tiger(name, weight, livinRegion, breed);
            }

            return animal;
        }
    }
}
