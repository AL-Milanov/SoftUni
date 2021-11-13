namespace ProductShop.ModelsDTO
{
    using System.Collections.Generic;

    public class SoldProductsDTO
    {
        public int Count => this.Products.Count;

        public ICollection<ProductNamePriceDTO> Products { get; set; }
    }
}
