namespace ProductShop.ModelsDTO
{
    using System.Collections.Generic;
    public class UsersCountDTO
    {
        public int UsersCount { get; set; }

        public ICollection<LastNameAgeSoldDTO> Users { get; set; }
    }
}
