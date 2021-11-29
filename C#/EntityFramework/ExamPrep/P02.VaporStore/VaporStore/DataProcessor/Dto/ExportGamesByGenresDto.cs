using System.Collections.Generic;

namespace VaporStore.DataProcessor.Dto
{
    public class ExportGenresDto
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public List<ExportGamesDto> Games{ get; set; }

        public int TotalPlayers { get; set; }
    }
}
