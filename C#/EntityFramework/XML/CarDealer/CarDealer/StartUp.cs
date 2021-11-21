namespace CarDealer
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
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

            //var input = File.ReadAllText("Datasets/sales.xml");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Customers");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportCustomersDto>), xmlRoot);

            var customersDto = (List<ImportCustomersDto>)xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = mapper.Map<List<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Sales");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSalesDto>), xmlRoot);

            var salesDto = (List<ImportSalesDto>)xmlSerializer.Deserialize(new StringReader(inputXml));
            var sales = new List<Sale>();

            var carIds = context.Cars.Select(c => c.Id).ToHashSet();

            foreach (var saleDto in salesDto)
            {
                if (carIds.Contains(saleDto.CarId))
                {
                    Sale sale = mapper.Map<Sale>(saleDto);

                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var carsDto = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarTravelledDistanceDto>(mapper.ConfigurationProvider)
                .ToList();

            var xmlRoot = new XmlRootAttribute("cars");
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var xmlSerializer = new XmlSerializer(typeof(List<ExportCarTravelledDistanceDto>), xmlRoot);


            xmlSerializer.Serialize(new StringWriter(sb), carsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bmwsDto = context.Cars
                .Where(c => c.Make.ToUpper() == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportBmwDto>(mapper.ConfigurationProvider)
                .ToList();

            var xmlRoot = new XmlRootAttribute("cars");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportBmwDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), bmwsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var localSuppliersDto = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSuppliersDto>(mapper.ConfigurationProvider)
                .ToList();

            var xmlRoot = new XmlRootAttribute("suppliers");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportLocalSuppliersDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), localSuppliersDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var carsAndPartsDto = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarsAndPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new ExportPartInfo
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(pc => pc.Price)
                        .ToList()
                })
                .Take(5)
                .ToList();


            var xmlRoot = new XmlRootAttribute("cars");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportCarsAndPartsDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), carsAndPartsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var customerSalesDto = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Include(c => c.Sales)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .ToList()
                .Select(c => new ExportSalesByCustomerDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(p => p.Car.PartCars.Sum(cp => cp.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            var xmlRoot = new XmlRootAttribute("customers");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportSalesByCustomerDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), customerSalesDto, namespaces);


            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();

            var salesDto = context.Sales
                .ProjectTo<ExportSalesWithDiscountDto>(mapper.ConfigurationProvider)
                .ToList();

            var xmlRoot = new XmlRootAttribute("sales");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportSalesWithDiscountDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), salesDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}