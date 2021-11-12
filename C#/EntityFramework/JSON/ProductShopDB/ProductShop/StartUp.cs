namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using ProductShop.Data;
    using ProductShop.Models;
    using ProductShop.ModelsDTO;

    public class StartUp
    {
        private static MapperConfiguration configurationProvider = new MapperConfiguration(cfg => {
            cfg.AddProfile<ProductShopProfile>();;
        });

        private static IMapper mapper = new Mapper(configurationProvider);

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(GetCategoriesByProductsCount(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            List<UserDTO> usersDto = JsonConvert.DeserializeObject<List<UserDTO>>(inputJson);


            var users = mapper.Map<List<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productsDto = JsonConvert.DeserializeObject<List<ProductDTO>>(inputJson);

            var products = mapper.Map<List<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var categoriesDto = JsonConvert.DeserializeObject<List<CategoryDTO>>(inputJson, settings)
                .Where(c => c.Name != null);

            var categories = mapper.Map<List<Category>>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProductsDto = JsonConvert.DeserializeObject<List<CategoryProductDTO>>(inputJson);

            var categoryProducts = mapper.Map<List<CategoryProduct>>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ProjectTo<ProductsInRangeDTO>(mapper.ConfigurationProvider)
                .ToList();

            string productsInRangeJson = JsonConvert.SerializeObject(productsInRange, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
            });

            return productsInRangeJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var userSoldProducts = context.Users
                .Where(u => u.ProductsSold.Where(ps => ps.BuyerId != null).Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserSoldProductsDTO>(mapper.ConfigurationProvider)
                .ToList();

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string soldProductsJson = JsonConvert.SerializeObject(userSoldProducts, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
            });

            return soldProductsJson;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProducts = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<CategoriesByProductsCountDTO>(mapper.ConfigurationProvider)
                .ToList();

            var contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            string categoriesByProductsJson = JsonConvert.SerializeObject(categoriesByProducts, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
            });

            return categoriesByProductsJson;
        }
    }
}