using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly Dictionary<int, IComputer> computers;
        private readonly Dictionary<int, IComponent> components;
        private readonly Dictionary<int, IPeripheral> peripherals;

        public Controller()
        {
            computers = new Dictionary<int, IComputer>();
            components = new Dictionary<int, IComponent>();
            peripherals = new Dictionary<int, IPeripheral>();
        }

        public string AddComponent(
            int computerId, int id, string componentType, string manufacturer, 
            string model, decimal price, double overallPerformance, int generation)
        {
            ComputerExcist(computerId);

            if (components.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            if (component == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            computers[computerId].AddComponent(component);
            components.Add(id, component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(id, computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, 
            string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            ComputerExcist(computerId);

            if (peripherals.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            if (peripheral == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            computers[computerId].AddPeripheral(peripheral);
            peripherals.Add(id, peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            var bestBuyComputers = computers.Values
                .OrderByDescending(c => c.OverallPerformance)
                .Where(p => p.Price <= budget)
                .FirstOrDefault();

            if (bestBuyComputers == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(bestBuyComputers.Id);

            return bestBuyComputers.ToString();
        }

        public string BuyComputer(int id)
        {
            ComputerExcist(id);

            var computerToRemove = computers[id];
            computers.Remove(id);

            return computerToRemove.ToString();
        }

        public string GetComputerData(int id)
        {
            ComputerExcist(id);

            return computers[id].ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ComputerExcist(computerId);

            var componentToRemove = computers[computerId].RemoveComponent(componentType);
            components.Remove(componentToRemove.Id);

            return string.Format(SuccessMessages.RemovedComponent, componentType, componentToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ComputerExcist(computerId);

            var peripheralToRemove = computers[computerId].RemovePeripheral(peripheralType);
            peripherals.Remove(peripheralToRemove.Id);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralToRemove.Id);
        }

        private void ComputerExcist(int computerId)
        {
            if (!computers.ContainsKey(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
