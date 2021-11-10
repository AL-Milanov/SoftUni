using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Item;
using FastFood.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext context;

        private readonly IMapper mapper;

        public ItemService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateItemDTO input)
        {
            var item = mapper.Map<Item>(input);

            context.Items.Add(item);
            context.SaveChanges();

        }

        public ICollection<AllItemsDTO> GetAll()
        {
            return context.Items.ProjectTo<AllItemsDTO>(mapper.ConfigurationProvider).ToList();
        }

        public ICollection<AllProductsIdsDTO> GetProductsIds()
        {
            return context.Categories.ProjectTo<AllProductsIdsDTO>(mapper.ConfigurationProvider).ToList();
        }
    }
}
