using AutoMapper;
using FastFood.Services.DTO.Positions;
using FastFood.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastFood.Core.ViewModels.Positions;

using System.Linq;
using System.Collections.Generic;

namespace FastFood.Core.Controllers
{
    public class PositionsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPositionService positionsService;

        public PositionsController(IMapper mapper, IPositionService positionsService)
        {
            this.mapper = mapper;
            this.positionsService = positionsService;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var position = this.mapper.Map<CreatePositionDTO>(model);

            positionsService.Create(position);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var positionsDto = positionsService.GetAll();

            var positions = 
                mapper.Map<ICollection<AllPositionsDTO>,
                ICollection<PositionsAllViewModel>>(positionsDto)
                .ToList();

            return this.View(positions);
        }
    }
}
