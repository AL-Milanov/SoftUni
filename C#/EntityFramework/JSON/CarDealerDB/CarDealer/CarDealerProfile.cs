namespace CarDealer
{
    using AutoMapper;

    using CarDealer.DTO.ImportsDTO;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Imports mapping
            this.CreateMap<ImportSupplierDTO, Supplier>();

            this.CreateMap<ImportPartsDTO, Part>();

            this.CreateMap<ImportCarsDTO, Car>()
                .ForMember(x => x.PartCars,
                           y => y.MapFrom(s => s.PartsId));

            this.CreateMap<ImportCustomerDTO, Customer>();

            this.CreateMap<ImportSalesDTO, Sale>();
        }
    }
}
