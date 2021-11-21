namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System.Linq;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Imports 
            this.CreateMap<ImportSuppliersDto, Supplier>()
                .ForMember(x => x.IsImporter,
                           y => y.MapFrom(s => bool.Parse(s.IsImporter)));

            this.CreateMap<ImportPartsDto, Part>();

            this.CreateMap<ImportCarsDto, Car>()
                .ForMember(x => x.PartCars,
                           y => y.MapFrom(s => s.Parts));

            this.CreateMap<ImportCustomersDto, Customer>();

            this.CreateMap<ImportSalesDto, Sale>();

            //Exports
            this.CreateMap<Car, ExportCarTravelledDistanceDto>();

            this.CreateMap<Car, ExportBmwDto>();

            this.CreateMap<Supplier, ExportLocalSuppliersDto>()
                .ForMember(x => x.PartsCount, 
                           y => y.MapFrom(s => s.Parts.Count));

            this.CreateMap<Car, ExportCarsAndPartsDto>()
                .ForMember(x => x.Parts,
                           y => y.MapFrom(s => s.PartCars));

            this.CreateMap<PartCar, ExportPartInfo>()
                .ForMember(x => x.Name,
                           y => y.MapFrom(s => s.Part.Name))
                .ForMember(x => x.Price,
                           y => y.MapFrom(s => s.Part.Price));

            this.CreateMap<Car, ExportCarDto>();

            this.CreateMap<Sale, ExportSalesWithDiscountDto>()
                .ForMember(x => x.CustomerName,
                           y => y.MapFrom(s => s.Customer.Name))
                .ForMember(x => x.Price,
                           y => y.MapFrom(s => s.Car.PartCars.Sum(p => p.Part.Price)))
                .ForMember(x => x.PriceWithDiscount,
                           y => y.MapFrom(s => (s.Car.PartCars.Sum(p => p.Part.Price) - 
                                               (s.Car.PartCars.Sum(p => p.Part.Price)) * (s.Discount / 100)).ToString("0.####")));

        }
    }
}
