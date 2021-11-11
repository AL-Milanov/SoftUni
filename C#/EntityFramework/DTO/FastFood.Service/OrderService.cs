namespace FastFood.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using FastFood.Data;
    using FastFood.Models;
    using FastFood.Services.DTO.Orders;
    using FastFood.Services.Interfaces;

    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly FastFoodContext context;

        private readonly IMapper mapper;

        public OrderService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateOrderDTO dto)
        {
            var employeeCustomer = mapper.Map<CustomerEmployeeDTO>(dto);

            var itemQuantity = mapper.Map<ItemQuantityDTO>(dto);

            var order = mapper.Map<Order>(employeeCustomer);

            var orderItems = mapper.Map<OrderItem>(itemQuantity);

            order.OrderItems.Add(orderItems);

            context.Orders.Add(order);
            context.SaveChanges();
        }

        public ICollection<AllOrdersDTO> GetAll()
        {
            return context.Orders.ProjectTo<AllOrdersDTO>(mapper.ConfigurationProvider).ToList();
        }

        public ItemsEmployeesDTO GetItemsAndEmployees()
        {
            var itemsEmployeesDto = new ItemsEmployeesDTO
            {
                Items = this.context.Items.Select(x => x.Id).ToList(),
                Employees = this.context.Employees.Select(x => x.Id).ToList(),
            };

            return itemsEmployeesDto;
        }
    }
}
