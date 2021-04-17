using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
			int n = int.Parse(Console.ReadLine());
			var engines = new List<Engine>();
			for (int i = 0; i < n; i++)
			{
				var engine = new Engine();

				string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
				string model = engineInfo[0];
				int power = int.Parse(engineInfo[1]);

				engine.Model = model;
				engine.Power = power;

				if (engineInfo.Length == 3)
				{
					string thirdParam = engineInfo[2];
					if (Char.IsDigit(thirdParam, 0))
					{
						string displacement = thirdParam;
						engine.Displacement = displacement;
					}
					else
					{
						string efficiency = thirdParam;
						engine.Efficiency = efficiency;
					}
				}
				else if (engineInfo.Length == 4)
				{
					string displacement = engineInfo[2];
					string efficiency = engineInfo[3];
					engine.Displacement = displacement;
					engine.Efficiency = efficiency;
				}

				engines.Add(engine);
			}

			int m = int.Parse(Console.ReadLine());
			List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
				string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
				string model = carData[0];
				string engine = carData[1];

				Car car = new Car();

				car.Model = model;
				car.CarEngine = engines.Where(e => e.Model == engine).FirstOrDefault();

                if (carData.Length == 3)
                {
					string thirdParam = carData[2];
					if (Char.IsDigit(thirdParam, 0))
					{
						car.Weight = thirdParam;
					}
					else
					{
						car.Color = thirdParam;
					}
				}
                else if (carData.Length == 4)
                {
					string weight = carData[2];
					string color = carData[3];
					car.Weight = weight;
					car.Color = color;
                }
				cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
		}
    }
}
