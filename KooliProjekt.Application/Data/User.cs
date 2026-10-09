using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Rakenduse kasutaja, kes ennustab jalgpallimängude skoore ja kogub punkte.
    /// </summary>
    public class User
    {
        /// <summary>Kasutaja unikaalne identifikaator.</summary>
        public int Id { get; set; }

        /// <summary>Kasutajanimi, millega kasutaja sisse logib.</summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>Kasutaja parool. Õppetöö näidis hoiab seda lihttekstina.</summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>Selle kasutaja mänguenustused.</summary>
        public IList<Prediction> Predictions { get; set; } = new List<Prediction>();

        /// <summary>Selle kasutaja punktiseisud turniiride kaupa.</summary>
        public IList<Scoreboard> Scoreboards { get; set; } = new List<Scoreboard>();
    }
}
