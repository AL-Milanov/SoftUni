namespace CarDealer
{
    using AutoMapper;
    using CarDealer.DTO.ExportsDTO;
    using CarDealer.DTO.ImportsDTO;
    using CarDealer.Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Imports maps
            this.CreateMap<ImportSupplierDTO, Supplier>();

            this.CreateMap<ImportPartsDTO, Part>();

            this.CreateMap<ImportCarsDTO, Car>()
                .ForMember(x => x.PartCars,
                           y => y.MapFrom(s => s.PartsId));

            this.CreateMap<ImportCustomerDTO, Customer>();

            this.CreateMap<ImportSalesDTO, Sale>();

            //Exports maps
            this.CreateMap<Customer, CustomersInfoDTO>();

            this.CreateMap<Car, ExportToyotaCarsDTO>();

            this.CreateMap<Supplier, ExportLocalSuppliers>()
                .ForMember(x => x.PartsCount,
                           y => y.MapFrom(s => s.Parts.Count));
        }
    }
}
