namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;
    using ProductShop.DTOs.Export;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp
    {
        private static readonly IConfigurationProvider configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        });

        private static readonly IMapper mapper = new Mapper(configuration);

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Users");
            var serializer = new XmlSerializer(typeof(List<ImportUsersDto>), root);

            var deserializeUsersDto = (List<ImportUsersDto>)serializer.Deserialize(new StringReader(inputXml));

            var users = mapper.Map<List<User>>(deserializeUsersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Products");
            var serializer = new XmlSerializer(typeof(List<ImportProductsDto>), root);

            var deserializerProductsDto = (List<ImportProductsDto>)serializer.Deserialize(new StringReader(inputXml));

            var products = mapper.Map<List<Product>>(deserializerProductsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Categories");
            var serializer = new XmlSerializer(typeof(List<ImportCategoriesDto>), root);

            var deserializerCategoriesDto = (List<ImportCategoriesDto>)serializer
                .Deserialize(new StringReader(inputXml));

            var categories = mapper.Map<List<Category>>(deserializerCategoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var root = new XmlRootAttribute("CategoryProducts");
            var serializer = new XmlSerializer(typeof(List<ImportCategoryProductsDto>), root);

            var deserializerCategoryProductsDto = (List<ImportCategoryProductsDto>)serializer
                .Deserialize(new StringReader(inputXml));

            var categoryProducts = mapper.Map<List<CategoryProduct>>(deserializerCategoryProductsDto);

            var categoryProductsSorted = categoryProducts
                .Where(cp => context.Categories.Any(c => c.Id == cp.CategoryId) &&
                context.Products.Any(p => p.Id == cp.ProductId))
                .ToList();

            context.CategoryProducts.AddRange(categoryProductsSorted);
            context.SaveChanges();

            return $"Successfully imported {categoryProductsSorted.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var productsInRangeDto = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProductsInRangeDto>(mapper.ConfigurationProvider)
                .ToList();

            var xmlRoot = new XmlRootAttribute("Products");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportProductsInRangeDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), productsInRangeDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var soldProductsDto = context.Users
                .Where(u => u.ProductsSold.Any(b => b.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<ExportUserSoldProductsDto>(mapper.ConfigurationProvider)
                .ToList();

            var xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportUserSoldProductsDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), soldProductsDto, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categoryProductsCountDto = context.Categories
                .ProjectTo<ExportCategoryProductsCountDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var xmlRoot = new XmlRootAttribute("Categories");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportCategoryProductsCountDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), categoryProductsCountDto, namespaces);

            return sb.ToString().TrimEnd();

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .OrderByDescending(u => u.ProductsSold.Where(ps => ps.BuyerId != null).Count())
                .ToList()
                .Select(u => new ExportUserInfoDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsCountDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold
                            .OrderByDescending(ps => ps.Price)
                            .Select(ps => new ExportSoldProductsDto
                            {
                                Name = ps.Name,
                                Price = ps.Price.ToString()
                            })
                            .ToList()
                    }
                })
                .Take(10)
                .ToList();

            var usersCount = new ExportUsersCountDto()
            {
                Count = usersWithProducts.Count,
                Users = usersWithProducts
            };

            var xmlRoot = new XmlRootAttribute("Users");
            var xmlSerializer = new XmlSerializer(typeof(ExportUsersCountDto), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            xmlSerializer.Serialize(new StringWriter(sb), usersCount, namespaces);


            return sb.ToString().TrimEnd();
        }
    }
}