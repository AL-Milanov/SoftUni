namespace SoftJail.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccesfullyImportDepartmentsCellsMessage =
            "Imported {0} with {1} cells";

        private const string SuccesFullyImportPrisonersMailMessage =
            "Imported {0} {1} years old";

        private const string SuccesFullyImportOfficersPrisonersMessage =
            "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var departmentsDto = JsonConvert.DeserializeObject<List<ImportDepartmentDto>>(jsonString);

            var departmentsDtoFiltered = new List<ImportDepartmentDto>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var departmentDtoFiltered = new ImportDepartmentDto
                {
                    Name = departmentDto.Name,
                };

                var cellsDto = new List<ImportCellDto>();

                bool isCellsValid = true;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isCellsValid = false;
                        break;
                    }

                    var isHasWindowValid = bool.TryParse(cellDto.HasWindow, out bool hasWindow);

                    if (!isHasWindowValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        isCellsValid = false;
                        continue;
                    }

                    var cellDtoFiltered = new ImportCellDto
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = hasWindow.ToString()
                    };

                    cellsDto.Add(cellDtoFiltered);
                }

                if (!isCellsValid)
                {
                    continue;
                }

                departmentDtoFiltered.Cells = cellsDto;

                departmentsDtoFiltered.Add(departmentDtoFiltered);

                sb.AppendLine(string.Format(SuccesfullyImportDepartmentsCellsMessage,
                    departmentDtoFiltered.Name, departmentDtoFiltered.Cells.Count));
            }

            var departments = Mapper.Map<List<Department>>(departmentsDtoFiltered);

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var prisonersDto = JsonConvert.DeserializeObject<List<ImportPrisonerDto>>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isMailValid = true;


                var incarcerationDateValidate = DateTime.TryParseExact(prisonerDto.IncarcerationDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var validIncarcerationDate);

                if (!incarcerationDateValidate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var releaseDateValidate = DateTime.TryParseExact(prisonerDto.ReleaseDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate);

                DateTime? validReleaseDate = releaseDate;

                var mailDtoFiltered = new List<Mail>(); 

                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        isMailValid = false;
                        break;
                    }

                    var validMailDto = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                    };

                    mailDtoFiltered.Add(validMailDto);
                }

                if (!isMailValid)
                {
                    continue;
                }

                var validPrisonerDto = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = validIncarcerationDate,
                    ReleaseDate = string.IsNullOrWhiteSpace(prisonerDto.ReleaseDate) ? null : validReleaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                };

                validPrisonerDto.Mails = mailDtoFiltered;

                prisoners.Add(validPrisonerDto);

                sb.AppendLine(string.Format(SuccesFullyImportPrisonersMailMessage,
                    validPrisonerDto.FullName, validPrisonerDto.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Officers");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportOfficersDto>), xmlRoot);

            using var sr = new StringReader(xmlString);

            var officersDto = (List<ImportOfficersDto>)xmlSerializer.Deserialize(sr);

            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out var position);

                if (!isPositionValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isWeaponValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out var weapon);

                if (!isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue; 
                }

                var officer = new Officer()
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Salary,
                    DepartmentId = officerDto.DepartmentId,
                    Position = (Position)position,
                    Weapon = (Weapon)weapon,
                };

                var officersPrisoners = new List<OfficerPrisoner>();

                foreach (var prisoner in officerDto.Prisoners)
                {
                    var officerPrisoner = new OfficerPrisoner()
                    {
                        PrisonerId = prisoner.Id,
                        Officer = officer
                    };

                    officersPrisoners.Add(officerPrisoner);
                }

                officer.OfficerPrisoners = officersPrisoners;

                officers.Add(officer);

                sb.AppendLine(string.Format(SuccesFullyImportOfficersPrisonersMessage,
                    officer.FullName, officer.OfficerPrisoners.Count));

            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}