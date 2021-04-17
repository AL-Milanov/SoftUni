using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink = null;

            if (type == DrinkType.Tea.ToString())
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == DrinkType.Water.ToString())
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return $"{string.Format(OutputMessages.DrinkAdded, name, brand)}";
        }

        public string AddFood(string type, string name, decimal price)
        {

            BakedFood bakedFood = null; //Should check if type is null ???

            if (type == BakedFoodType.Bread.ToString())
            {
                bakedFood = new Bread(name, price);
            }
            else if (type == BakedFoodType.Cake.ToString())
            {
                bakedFood = new Cake(name, price);
            }

            bakedFoods.Add(bakedFood);

            return $"{string.Format(OutputMessages.FoodAdded, name, type) }";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;

            if (type == TableType.InsideTable.ToString())
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == TableType.OutsideTable.ToString())
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            tables.Add(table);

            return $"{string.Format(OutputMessages.TableAdded, tableNumber)}";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.FindAll(t => t.IsReserved == false);
            StringBuilder sb = new StringBuilder();

            foreach (var freeTable in freeTables)
            {
                sb.AppendLine($"{freeTable.GetFreeTableInfo()}");
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.First(t => t.TableNumber == tableNumber);
            var bill = table.GetBill();
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            totalIncome += bill;

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            Drink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {

                return $"{string.Format(OutputMessages.WrongTableNumber, tableNumber)}";
            }

            if (drink == null)
            {

                return $"{string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand)}";
            }

            table.OrderDrink(drink);
            return $"{string.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand)}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            Table table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            BakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {

                return $"{string.Format(OutputMessages.WrongTableNumber, tableNumber)}";
            }

            if (food == null)
            {

                return $"{string.Format(OutputMessages.NonExistentFood, foodName)}";
            }

            table.OrderFood(food);
            return $"{string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName)}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table freeTable = tables.FirstOrDefault(
                t => t.IsReserved == false && t.Capacity >= numberOfPeople); // probably == ??

            if (freeTable == null)
            {

                return $"{string.Format(OutputMessages.ReservationNotPossible, numberOfPeople)}";
            }

            freeTable.Reserve(numberOfPeople);
            return $"{string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople)}";
        }
    }
}
