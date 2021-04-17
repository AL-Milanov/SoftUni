using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;

            this.data = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = data.Where(m => m.Manufacturer == manufacturer)
                .Where(m => m.Model == model)
                .FirstOrDefault();
            
            if (car == null)
            {
                return false;
            }

            data.Remove(car);
            return true;
        }

        public Car GetLatestCar()
        {
            Car car = data.OrderByDescending(a => a.Year).FirstOrDefault();
            
            return car;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = data.Where(m => m.Manufacturer == manufacturer)
                .Where(m => m.Model == model)
                .FirstOrDefault();
            
            return car;
        }

        public string GetStatistics()
        {
            
            string result = $"The cars are parked in {Type}:" + Environment.NewLine;

            for (int i = 0; i < data.Count; i++)
            {
                if (data.Count - 1 == i)
                {
                    result += $"{data[i]}";
                }
                else
                {
                    result += $"{data[i]}" + Environment.NewLine;
                }
            }

            return result;
        }
    }
}
