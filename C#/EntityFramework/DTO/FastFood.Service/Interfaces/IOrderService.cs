namespace FastFood.Services.Interfaces
{
    using FastFood.Services.DTO.Orders;
    using System.Collections.Generic;

    public interface IOrderService
    {
        void Create(CreateOrderDTO dto);

        ICollection<AllOrdersDTO> GetAll();

        ItemsEmployeesDTO GetItemsAndEmployees();
    }
}
