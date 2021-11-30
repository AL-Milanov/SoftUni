namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisonersDto = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .ToList()
                .Select(p => new ExportPrisonersByCellsDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(o => new ExportOfficerDto
                        {
                            OfficerName = o.Officer.FullName,
                            Department = o.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = p.PrisonerOfficers
                        .Select(o => o.Officer)
                        .Sum(o => o.Salary)
                })
                .OrderBy(o => o.Name)
                .ThenBy(o => o.Id)
                .ToList();

            var prisonersJson = JsonConvert.SerializeObject(prisonersDto, Formatting.Indented);

            return prisonersJson;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            StringBuilder sb = new StringBuilder();

            var prisonersNamesArray = prisonersNames.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var prisonersInboxDto = context.Prisoners
                .Where(p => prisonersNamesArray.Contains(p.FullName))
                .ToList()
                .Select(p => new ExportPrisonerMailDto
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                        .Select(m => new ExportMessagesDto
                        {
                            Description = string.Join("", m.Description.Reverse()),
                        })
                        .ToList()
                        
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToList();

            var xmlRoot = new XmlRootAttribute("Prisoners");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportPrisonerMailDto>), xmlRoot);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            xmlSerializer.Serialize(sw, prisonersInboxDto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}