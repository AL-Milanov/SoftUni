namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.DTO.ImportsDTO;
    using CarDealer.Models;
    using Newtonsoft.Json;

    public class StartUp
    {

        private static IConfigurationProvider configurationProvider = new MapperConfiguration(m => 
        { 
            m.AddProfile<CarDealerProfile>(); 
        });

        private static IMapper mapper = new Mapper(configurationProvider);

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //var suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            var salesJson = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliersJson));
            //Console.WriteLine(ImportParts(context, partsJson));
            //Console.WriteLine(ImportCars(context, carsJson));
            //Console.WriteLine(ImportCustomers(context, customersJson));
            Console.WriteLine(ImportSales(context, salesJson));

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDto = JsonConvert.DeserializeObject<ICollection<ImportSupplierDTO>>(inputJson);

            var suppliers = mapper.Map<ICollection<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var partsDto = JsonConvert.DeserializeObject<ICollection<ImportPartsDTO>>(inputJson);

            var parts = mapper.Map<ICollection<Part>>(partsDto).Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ICollection<ImportCarsDTO>>(inputJson);

            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var uniqueParts = carDto.PartsId
                    .Distinct()
                    .ToList();

                foreach (var partId in uniqueParts)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId,
                        CarId = car.Id
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<ICollection<ImportCustomerDTO>>(inputJson);

            var customers = mapper.Map<ICollection<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<ICollection<ImportSalesDTO>>(inputJson);

            var sales = mapper.Map<ICollection<Sale>>(salesDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }
    }
}