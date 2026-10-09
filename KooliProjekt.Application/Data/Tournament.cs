using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Turniir või liigahooaeg, mille mängudele kasutajad ennustusi teevad.
    /// </summary>
    public class Tournament
    {
        /// <summary>Turniiri unikaalne identifikaator.</summary>
        public int Id { get; set; }

        /// <summary>Turniiri nimi koos hooajaga, näiteks Premier League 2024/25.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Sellel turniiril peetavad mängud.</summary>
        public IList<Match> Matches { get; set; } = new List<Match>();

        /// <summary>Kasutajate punktiseisud sellel turniiril.</summary>
        public IList<Scoreboard> Scoreboards { get; set; } = new List<Scoreboard>();
    }
}
