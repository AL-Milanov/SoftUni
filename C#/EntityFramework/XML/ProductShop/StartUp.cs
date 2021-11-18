namespace ProductShop
{
    using AutoMapper;

    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
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

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var inputXml = File.ReadAllText("Datasets/categories-products.xml");

            Console.WriteLine(ImportCategoryProducts(context, inputXml));
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
    }
}