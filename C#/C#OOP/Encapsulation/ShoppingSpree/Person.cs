using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;


        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        //name, money and a bag of products

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Money 
        //??
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.money = value;
            }
        } 

        public List<string> BagOfProducts { get; private set; }


        public string BuyProduct(string product, double cost)
        {
            if (cost <= money)
            {
                BagOfProducts.Add(product);
                money -= cost;
                return $"{Name} bought {product}";
            }

            return $"{Name} can't afford {product}";
        }
    }
}
