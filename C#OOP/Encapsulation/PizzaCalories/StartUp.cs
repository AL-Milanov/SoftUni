using System;

namespace PizzaCalories
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInput = Console.ReadLine().Split();
                string[] doughInput = Console.ReadLine().Split();
                Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                Pizza pizza = new Pizza(pizzaInput[1]);
                pizza.DoughType = dough;


                while (true)
                {

                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    string[] toppingInput = input.Split();
                    Topping topping = new Topping(toppingInput[1], int.Parse(toppingInput[2]));
                    pizza.AddTopping(topping);

                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
