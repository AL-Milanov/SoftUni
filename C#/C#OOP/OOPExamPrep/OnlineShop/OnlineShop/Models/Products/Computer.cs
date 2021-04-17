using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance => components.Count == 0
            ? base.OverallPerformance
            : base.OverallPerformance + components.Average(c => c.OverallPerformance);

        public override decimal Price => base.Price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);

        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                throw new ArgumentException(
                    $"Component {component.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException(
                    $"Peripheral {peripheral.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(
                    $"Component {componentType} does not exist in {GetType().Name} with Id {Id}.");
            }

            components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(
                    $"Peripheral {peripheralType} does not exist in {GetType().Name} with Id {Id}.");
            }

            peripherals.Remove(peripheral);
            return peripheral;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {OverallPerformance:f2}. " +
                $"Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");

            sb.AppendLine($" Components ({components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            var peripheralsAverage = peripherals.Count == 0
                ? 0
                : peripherals.Average(p => p.OverallPerformance);
            sb.AppendLine($" Peripherals ({peripherals.Count});" +
                $" Average Overall Performance ({peripheralsAverage:f2}):");
            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
