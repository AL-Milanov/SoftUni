namespace ProductShop
{
    using AutoMapper;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Import mappings
            this.CreateMap<ImportUsersDto, User>()
                .ForMember(x => x.Age,
                           y => y.MapFrom(a => int.Parse(a.Age)));

            this.CreateMap<ImportProductsDto, Product>();

            this.CreateMap<ImportCategoriesDto, Category>();
        }
    }
}
