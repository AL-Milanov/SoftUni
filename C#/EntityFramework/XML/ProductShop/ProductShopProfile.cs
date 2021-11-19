namespace ProductShop
{
    using AutoMapper;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;
    using System.Collections.Generic;
    using System.Linq;

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

            this.CreateMap<ImportCategoryProductsDto, CategoryProduct>();

            //Export mappings
            this.CreateMap<Product, ExportProductsInRangeDto>()
                .ForMember(x => x.Buyer,
                           y => y.MapFrom(s => $"{s.Buyer.FirstName} {s.Buyer.LastName}"))
                .ForMember(x => x.Price,
                           y => y.MapFrom(s => s.Price.ToString()));

            this.CreateMap<Product, ExportSoldProductsDto>()
                .ForMember(x => x.Price,
                           y => y.MapFrom(s => s.Price.ToString()));

            this.CreateMap<User, ExportUserSoldProductsDto>()
                .ForMember(x => x.SoldProducts,
                           y => y.MapFrom(s => s.ProductsSold));

            this.CreateMap<Category, ExportCategoryProductsCountDto>()
                .ForMember(x => x.Count, 
                           y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice,
                           y => y.MapFrom(s => 
                           (s.CategoryProducts.Sum(p => p.Product.Price) / s.CategoryProducts.Count).ToString()))
                .ForMember(x => x.TotalRevenue,
                           y => y.MapFrom(s => s.CategoryProducts.Sum(p => p.Product.Price)));

            this.CreateMap<User, ExportUserInfoDto>()
                .ForMember(x => x.SoldProducts,
                           y => y.MapFrom(s => s.ProductsSold));
        }
    }
}
