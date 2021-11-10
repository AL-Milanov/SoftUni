namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Models;
    using FastFood.Services.DTO.Category;
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

            this.CreateMap<PositionsAllViewModel, AllPositionsDTO>();

            this.CreateMap<AllPositionsDTO, PositionsAllViewModel>();

            this.CreateMap<Position, AllPositionsDTO>();

            //Categories
            this.CreateMap<CreateCategoryDTO, Category>();

            this.CreateMap<CreateCategoryInputModel, CreateCategoryDTO>()
                .ForMember(x => x.Name,
                           y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, AllCategoriesDTO>();

            this.CreateMap<AllCategoriesDTO, CategoryAllViewModel>();
        }
    }
}
