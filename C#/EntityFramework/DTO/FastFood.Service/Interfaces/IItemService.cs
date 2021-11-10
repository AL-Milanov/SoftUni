using FastFood.Services.DTO.Item;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface IItemService
    {
        void Create(CreateItemDTO input);

        ICollection<AllProductsIdsDTO> GetProductsIds();

        ICollection<AllItemsDTO> GetAll();


    }
}
