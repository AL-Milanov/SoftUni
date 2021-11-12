namespace ProductShop.ModelsDTO
{
    using System.Collections.Generic;

    public class UserSoldProductsDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<SoldProductsDTO> SoldProducts { get; set; }
    }
}
