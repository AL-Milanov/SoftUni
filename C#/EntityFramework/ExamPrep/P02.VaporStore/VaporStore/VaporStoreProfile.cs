namespace VaporStore
{
	using AutoMapper;
    using System;
    using System.Globalization;
    using VaporStore.Data.Enum;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto;

    public class VaporStoreProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public VaporStoreProfile()
		{
			//Imports 
			this.CreateMap<ImportUserDto, User>();

			this.CreateMap<ImportCardDto, Card>()
				.ForMember(x => x.Type,
						   y => y.MapFrom(s => Enum.Parse(typeof(CardType), s.Type)));


		}
	}
}