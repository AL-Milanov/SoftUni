namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Models;
    using ProductShop.ModelsDTO;
    using System.Linq;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {

            this.CreateMap<UserDTO, User>();

            this.CreateMap<ProductDTO, Product>();

            this.CreateMap<CategoryDTO, Category>();

            this.CreateMap<CategoryProductDTO, CategoryProduct>();

            this.CreateMap<Product, ProductsInRangeDTO>()
                .ForMember(x => x.Seller,
                           y => y.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, SoldProductsDTO>()
                .ForMember(x => x.BuyerFirstName,
                           y => y.MapFrom(s => s.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName,
                           y => y.MapFrom(s => s.Buyer.LastName));

            this.CreateMap<User, UserSoldProductsDTO>()
                .ForMember(x => x.SoldProducts,
                           y => y.MapFrom(s => s.ProductsSold));

            this.CreateMap<Category, CategoriesByProductsCountDTO>()
                .ForMember(x => x.Category,
                           y => y.MapFrom(s => s.Name))
                .ForMember(x => x.ProductsCount,
                           y => y.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice,
                           y => y.MapFrom(s => $"{s.CategoryProducts.Average(p => p.Product.Price):f2}"))
                .ForMember(x => x.TotalRevenue,
                           y => y.MapFrom(s => $"{s.CategoryProducts.Sum(p => p.Product.Price)}"));
        }
    }
}
