namespace CarDealer
{
    using AutoMapper;
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


        }
    }
}
