namespace TeisterMask
{
    using AutoMapper;
    using System.Globalization;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ExportDto;
    using TeisterMask.DataProcessor.ImportDto;

    public class TeisterMaskProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public TeisterMaskProfile()
        {
            //Imports

            this.CreateMap<ImportProjectsDto, Project>();

            this.CreateMap<ImportTaskDto, Task>();


            //Exports

            this.CreateMap<EmployeeTask, ExportTasksDto>()
                .ForMember(x => x.TaskName,
                           y => y.MapFrom(s => s.Task.Name))
                .ForMember(x => x.OpenDate,
                           y => y.MapFrom(s => s.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(x => x.DueDate,
                           y => y.MapFrom(s => s.Task.DueDate.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(x => x.LabelType,
                           y => y.MapFrom(s => s.Task.LabelType.ToString()))
                .ForMember(x => x.ExecutionType,
                           y => y.MapFrom(s => s.Task.ExecutionType.ToString()));
        }
    }
}
