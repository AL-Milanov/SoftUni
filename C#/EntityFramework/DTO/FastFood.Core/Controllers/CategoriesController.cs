namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;

        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var category = mapper.Map<CreateCategoryDTO>(model);

            categoryService.Create(category);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var categoriesDto = categoryService.GetAll();

            var categories = mapper.Map<ICollection<AllCategoriesDTO>,
                ICollection<CategoryAllViewModel>>(categoriesDto)
                .ToList();

            return this.View(categories);
        }
    }
}
