using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Category;
using FastFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext context;
        
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateCategoryDTO categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);

            context.Categories.Add(category);
            context.SaveChanges();
        }

        public ICollection<AllCategoriesDTO> GetAll()
        {
            return context.Categories.ProjectTo<AllCategoriesDTO>(mapper.ConfigurationProvider).ToList();
        }
    }
}
