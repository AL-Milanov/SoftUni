using FastFood.Services.DTO.Positions;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface IPositionService
    {
        public void Create(CreatePositionDTO position);

        public ICollection<AllPositionsDTO> GetAll();
    }
}
