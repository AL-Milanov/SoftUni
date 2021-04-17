using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly Dictionary<string, IComponent> components;
        private readonly Dictionary<string, IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new Dictionary<string, IComponent>();
            peripherals = new Dictionary<string, IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.Values.ToList();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.Values.ToList();

        //maybe without peripherals ???
        public override double OverallPerformance => base.OverallPerformance +
            components.Values.Average(c => c.OverallPerformance);

        public override decimal Price => base.Price +
            components.Values.Sum(c => c.Price) +
            peripherals.Values.Sum(p => p.Price);

        public void AddComponent(IComponent component)
        {
            //check if component is null ??
            string componentType = component.GetType().Name;

            if (components.ContainsKey(componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                                                                            componentType,
                                                                            GetType().Name,
                                                                            Id));
            }

            components.Add(componentType, component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {

            string peripheralType = peripheral.GetType().Name;

            if (peripherals.ContainsKey(peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                                                                            peripheralType,
                                                                            GetType().Name,
                                                                            Id));
            }

            peripherals.Add(peripheralType, peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !components.ContainsKey(componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                                                                            componentType,
                                                                            GetType().Name,
                                                                            Id));
            }

            var componentToRemove = components[componentType];
            components.Remove(componentType);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !peripherals.ContainsKey(peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                                                                            peripheralType,
                                                                            GetType().Name,
                                                                            Id));
            }

            var peripheralToRemove = peripherals[peripheralType];
            peripherals.Remove(peripheralType);

            return peripheralToRemove;
        }

        public override string ToString()
        {

            string result = base.ToString() + Environment.NewLine;

            result += string.Format(SuccessMessages.ComputerComponentsToString, components.Values.Count)
                + Environment.NewLine;

            foreach (var comp in components)
            {
                result += $"  {comp.Value}" + Environment.NewLine;
            }

            double peripheralsAvg = peripherals.Values.Count != 0
                ? peripherals.Average(p => p.Value.OverallPerformance)
                : 0;
            result += string.Format(SuccessMessages.ComputerPeripheralsToString,
                peripherals.Values.Count,
                $"{peripheralsAvg:f2}")
                + Environment.NewLine;
            foreach (var per in peripherals)
            {
                result += $"  {per.Value}" + Environment.NewLine;
            }

            return result.TrimEnd();
        }
    }
}
