namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Services.DTO.Category;
    using FastFood.Services.DTO.Employee;
    using FastFood.Services.DTO.Item;
    using FastFood.Services.DTO.Orders;
    using FastFood.Services.DTO.Positions;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, CreatePositionDTO>();

            this.CreateMap<CreatePositionDTO, Position>()
                .ForMember(x => x.Name,
                           y => y.MapFrom(s => s.PositionName));

            this.CreateMap<AllPositionsDTO, PositionsAllViewModel>()
                .ForMember(x => x.Name,
                           y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, AllPositionsDTO>()
                .ForMember(x => x.PositionName,
                           y => y.MapFrom(s => s.Name))
                .ForMember(x => x.PositionId,
                           y => y.MapFrom(s => s.Id));

            //Categories
            this.CreateMap<CreateCategoryDTO, Category>();

            this.CreateMap<CreateCategoryInputModel, CreateCategoryDTO>()
                .ForMember(x => x.Name,
                           y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, AllCategoriesDTO>();

            this.CreateMap<AllCategoriesDTO, CategoryAllViewModel>();

            //Items

             //Create view
            this.CreateMap<Category, AllProductsIdsDTO>()
                .ForMember(x => x.CategoryId, 
                           y => y.MapFrom(s => s.Id));
            //Create view
           this.CreateMap<AllProductsIdsDTO, CreateItemViewModel>();

            this.CreateMap<CreateItemInputModel, CreateItemDTO>();

            this.CreateMap<CreateItemDTO, Item>();

            this.CreateMap<Item, AllItemsDTO>()
                .ForMember(x => x.Category,
                           y => y.MapFrom(s => s.Category.Name));

            this.CreateMap<AllItemsDTO, ItemsAllViewModels>();

            //Employees

                //Mapping in service
            this.CreateMap<CreateEmployeeDTO, Employee>();

            this.CreateMap<Employee, AllEmployeeDTO>()
                .ForMember(x => x.Position,
                           y => y.MapFrom(s => s.Position.Name));

            this.CreateMap<AllEmployeeDTO, EmployeesAllViewModel>()
                .ForMember(x => x.PositionName,
                           y => y.MapFrom(s => s.Position));

            this.CreateMap<Position, EmployeePositionsIdDTO>()
                .ForMember(x => x.PositionId,
                           y => y.MapFrom(s => s.Id))
                .ForMember(x => x.PositionName,
                           y => y.MapFrom(s => s.Name));

                //Mapping in controller
            this.CreateMap<Position, AllEmployeeDTO>()
                .ForMember(x => x.Position,
                           y => y.MapFrom(s => s.Name));

            this.CreateMap<EmployeePositionsIdDTO, RegisterEmployeeViewModel>();

            this.CreateMap<RegisterEmployeeInputModel, CreateEmployeeDTO>();

            //Orders

            //Service
            this.CreateMap<CreateOrderDTO, CustomerEmployeeDTO>();

            this.CreateMap<CreateOrderDTO, ItemQuantityDTO>();

            this.CreateMap<CustomerEmployeeDTO, Order>();

            this.CreateMap<ItemQuantityDTO, OrderItem>();

            this.CreateMap<Order, AllOrdersDTO>()
                .ForMember(x => x.OrderId,
                           y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Employee,
                           y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.DateTime,
                           y => y.MapFrom(s => s.DateTime.ToString("dd/MM/yyyy")));

            //Controller
            this.CreateMap<CreateOrderInputModel, CreateOrderDTO>();

            this.CreateMap<ItemsEmployeesDTO, CreateOrderViewModel>();

            this.CreateMap<AllOrdersDTO, OrderAllViewModel>();

            
        }
    }
}
