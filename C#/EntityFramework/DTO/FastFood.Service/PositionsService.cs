using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Positions;
using FastFood.Services.Interfaces;

using System.Linq;
using System.Collections.Generic;

namespace FastFood.Services
{
    public class PositionsService : IPositionService
    {
        private readonly FastFoodContext context;

        private readonly IMapper mapper;

        public PositionsService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreatePositionDTO input)
        {
            var position = mapper.Map<Position>(input);

            this.context.Positions.Add(position);

            this.context.SaveChanges();
        }

        public ICollection<AllPositionsDTO> GetAll()
        {
            return context.Positions.ProjectTo<AllPositionsDTO>(mapper.ConfigurationProvider).ToList();
        }
    }
}
