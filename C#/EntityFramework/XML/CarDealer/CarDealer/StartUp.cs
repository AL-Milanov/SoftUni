namespace CarDealer
{
    using AutoMapper;

    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;


    public class StartUp
    {
        private static IConfigurationProvider configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        });

        private static IMapper mapper = new Mapper(configuration);

        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var input = File.ReadAllText("Datasets/cars.xml");

            Console.WriteLine(ImportCars(context, input));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Suppliers");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSuppliersDto>), xmlRoot);

            var suppliersDto = (List<ImportSuppliersDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = mapper.Map<List<Supplier>>(suppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Parts");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportPartsDto>), xmlRoot);

            var partsDto = (List<ImportPartsDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = mapper.Map<List<Part>>(partsDto);

            var partsSorted = parts.Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId)).ToList();

            context.Parts.AddRange(partsSorted);
            context.SaveChanges();

            return $"Successfully imported {partsSorted.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Cars");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCarsDto>), xmlRoot);

            var carsDto = (List<ImportCarsDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {

                Car car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance
                };

                foreach (var partId in carDto.Parts.Select(p => p.PartId).Distinct())
                {
                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    PartCar part = new PartCar
                    {
                        PartId = partId,
                        Car = car
                    };

                    car.PartCars.Add(part);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
    }
}