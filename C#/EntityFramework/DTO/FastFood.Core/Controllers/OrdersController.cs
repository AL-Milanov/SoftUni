namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data;
    using FastFood.Services.DTO.Orders;
    using FastFood.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IMapper mapper;

        private readonly IOrderService orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            this.mapper = mapper;
            this.orderService = orderService;
        }

        public IActionResult Create()
        {
            ItemsEmployeesDTO itemsEmployeesDto = orderService.GetItemsAndEmployees();

            var itemsEmployeesView = mapper.Map<CreateOrderViewModel>(itemsEmployeesDto);

            return this.View(itemsEmployeesView);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var orderDto = mapper.Map<CreateOrderDTO>(model);

            orderService.Create(orderDto);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var ordersDto = orderService.GetAll();

            var ordersView = mapper.Map<ICollection<OrderAllViewModel>>(ordersDto);

            return this.View(ordersView);
        }
    }
}
