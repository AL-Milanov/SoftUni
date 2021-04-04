using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private Dictionary<int, IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            computers = new Dictionary<int, IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType,
            string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            ComputerExist(computerId);

            var componentExist = components.FirstOrDefault(c => c.Id == id);

            if (componentExist != null)
            {
                throw new ArgumentException("Component with this id already exists.");
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
                throw new ArgumentException("Component type is invalid.");
            }

            computers[computerId].AddComponent(component);
            components.Add(component);
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            //doesnt have to check if id exist
            if (computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = null;

            if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            if (computer == null)
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            computers.Add(id, computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType,
            string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            ComputerExist(computerId);

            var peripheralExist = peripherals.FirstOrDefault(p => p.Id == id);
            if (peripheralExist != null)
            {
                throw new ArgumentException("Peripheral with this id already exists.");
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
                throw new ArgumentException("Peripheral type is invalid.");
            }

            computers[computerId].AddPeripheral(peripheral);
            peripherals.Add(peripheral);
            return $"Peripheral {peripheral.GetType().Name} with id {id} added successfully " +
                $"in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            //doesnt have to check if id exist
            var computer = computers.Values
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            computers.Remove(computer.Id);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            ComputerExist(id);
            IComputer computer = computers[id];
            computers.Remove(id);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            ComputerExist(id);

            return computers[id].ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            ComputerExist(computerId);
            var component = components.FirstOrDefault(c => c.GetType().Name == componentType);
            computers[computerId].RemoveComponent(componentType);
            components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ComputerExist(computerId);
            var peripheral = peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            computers[computerId].RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        private void ComputerExist(int computerId)
        {
            if (computers.ContainsKey(computerId) == false)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
