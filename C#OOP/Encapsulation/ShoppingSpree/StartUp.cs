using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] customersInput = Console.ReadLine().Split(";");
            string[] productInput = Console.ReadLine().Split(";");
            List<Person> customers = new List<Person>();
            List<Product> products = new List<Product>();


            try
            {
                for (int i = 0; i < customersInput.Length; i++)
                {
                    string[] splited = customersInput[i].Split("=");

                    Person currentCustomer = new Person(splited[0], int.Parse(splited[1]));
                    customers.Add(currentCustomer);
                }
                for (int i = 0; i < productInput.Length; i++)
                {
                    string[] splited = productInput[i].Split("=");

                    Product currentProduct = new Product(splited[0], double.Parse(splited[1]));
                    products.Add(currentProduct);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] cmdArgs = command.Split();
                    string name = cmdArgs[0];
                    string product = cmdArgs[1];
                    Person customerMatch = customers.FirstOrDefault(n => n.Name == name);
                    Product productMatch = products.FirstOrDefault(p => p.Name == product);


                    if (customerMatch != null && productMatch != null)
                    {
                        Console.WriteLine(customerMatch.BuyProduct(product, productMatch.Cost));
                    }


                    command = Console.ReadLine();
                }


                foreach (var item in customers)
                {
                    if (item.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{item.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} - {String.Join(", ", item.BagOfProducts)}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
