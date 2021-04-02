using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private bool isReserved;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            isReserved = false;
        }


        public int TableNumber { get; private set; }

        public int Capacity 
        {
            get => capacity;
            private set
            {

                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople 
        {
            get => this.numberOfPeople;
            private set
            {

                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved => isReserved;

        //TODO
        public decimal Price => (PricePerPerson * NumberOfPeople) ;

        public void Clear()
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            isReserved = false;
            
        }

        public decimal GetBill()
        {
            decimal bill = foodOrders.Sum(f => f.Price) + drinkOrders.Sum(d => d.Price) + Price;

            return bill;
        }

        public string GetFreeTableInfo()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            if (Capacity >= NumberOfPeople)
            {
                isReserved = true;
            }
        }
    }
}
