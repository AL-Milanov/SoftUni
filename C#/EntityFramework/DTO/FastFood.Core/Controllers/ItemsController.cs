namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Services.DTO.Item;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IMapper mapper;

        private readonly IItemService itemService;

        public ItemsController(IMapper mapper, IItemService itemService)
        {
            this.mapper = mapper;
            this.itemService = itemService;
        }

        public IActionResult Create()
        {
            var itemsDto = itemService.GetProductsIds();

            var items = mapper.Map<ICollection<AllProductsIdsDTO>,
                ICollection<CreateItemViewModel>>(itemsDto)
                .ToList();

            return this.View(items);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var itemDto = mapper.Map<CreateItemDTO>(model);

            itemService.Create(itemDto);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var itemsDto = itemService.GetAll();

            var items = mapper.Map<ICollection<AllItemsDTO>,
                ICollection<ItemsAllViewModels>>(itemsDto)
                .ToList();

            return this.View(items);
        }
    }
}
