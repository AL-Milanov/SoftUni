using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double money;

        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Cost
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 1)
                {
                    throw new Exception("Money cannot be negative");
                }

                this.money = value;
            }
        }  //??


    }
}
