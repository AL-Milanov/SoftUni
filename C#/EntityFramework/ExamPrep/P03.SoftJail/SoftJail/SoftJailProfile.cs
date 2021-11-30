namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Globalization;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            //Imports

            this.CreateMap<ImportDepartmentDto, Department>();

            this.CreateMap<ImportCellDto, Cell>()
                .ForMember(x => x.HasWindow,
                           y => y.MapFrom(s => bool.Parse(s.HasWindow)));

        }
    }
}
