using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<string, List<Vehicle>> shop;

        private List<Vehicle> vehicles;

        private Dictionary<string, List<Vehicle>> byBrand;

        public VehicleRepository()
        {
            shop = new Dictionary<string, List<Vehicle>>();
            vehicles = new List<Vehicle>();
            byBrand = new Dictionary<string, List<Vehicle>>();
        }

        public int Count => vehicles.Count;

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (!shop.ContainsKey(sellerName))
            {
                shop[sellerName] = new List<Vehicle>();
            }

            if (!byBrand.ContainsKey(vehicle.Brand))
            {
                byBrand[vehicle.Brand] = new List<Vehicle>();
            }

            vehicle.SellerName = sellerName;

            shop[sellerName].Add(vehicle);
            vehicles.Add(vehicle);
            byBrand[vehicle.Brand].Add(vehicle);
        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!shop.ContainsKey(sellerName) || shop[sellerName].Count == 0)
            {
                throw new ArgumentException();
            }

            return shop[sellerName].OrderBy(v => v.Price).First();
        }

        public bool Contains(Vehicle vehicle)
        {
            return vehicles.Contains(vehicle);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (Count == 0)
            {
                throw new ArgumentException();
            }

            var ordered = new Dictionary<string, List<Vehicle>>();

            foreach (var car in byBrand)
            {
                ordered.Add(car.Key, car.Value.OrderBy(v => v.Price).ToList());
            }

            return ordered;
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            return vehicles.OrderByDescending(v => v.Horsepower).ThenBy(v => v.Price).ThenBy(v => v.SellerName);
        }

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            var matchedVehicles = new List<Vehicle>();

            foreach (var car in vehicles)
            {
                if (keywords.Contains(car.Brand))
                {
                    matchedVehicles.Add(car);
                }
                else if (keywords.Contains(car.Model))
                {
                    matchedVehicles.Add(car);
                }
                else if (keywords.Contains(car.Location))
                {
                    matchedVehicles.Add(car);
                }
                else if (keywords.Contains(car.Color))
                {
                    matchedVehicles.Add(car);
                }
            }

            return matchedVehicles.OrderByDescending(v => v.IsVIP).ThenBy(v => v.Price);
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!shop.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            return shop[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            return vehicles.Where(v => v.Price >= lowerBound && v.Price <= upperBound).OrderByDescending(v => v.Horsepower);
        }

        public void RemoveVehicle(string vehicleId)
        {
            var vehicleToRemove = vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (vehicleToRemove == null)
            {
                throw new ArgumentException();
            }

            vehicles.Remove(vehicleToRemove);
            byBrand[vehicleToRemove.Brand].Remove(vehicleToRemove);

            foreach (var vehicle in shop.Values)
            {
                if (vehicle.Contains(vehicleToRemove))
                {
                    vehicle.Remove(vehicleToRemove);
                    break;
                }
            }
        }
    }
}
