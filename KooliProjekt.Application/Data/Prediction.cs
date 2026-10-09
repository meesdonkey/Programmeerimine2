namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Kasutaja ennustus ühe mängu lõppskoori kohta ja selle eest saadud punktid.
    /// </summary>
    public class Prediction
    {
        /// <summary>Ennustuse unikaalne identifikaator.</summary>
        public int Id { get; set; }

        /// <summary>Ennustatud skoor esimesele võistkonnale.</summary>
        public int Team1Score { get; set; }

        /// <summary>Ennustatud skoor teisele võistkonnale.</summary>
        public int Team2Score { get; set; }

        /// <summary>
        /// Punktid: 5 täpse skoori eest, 2 õige võitja või viigi eest, muidu 0.
        /// </summary>
        public int Points { get; set; }

        /// <summary>Mäng, millele ennustus tehti.</summary>
        public int MatchId { get; set; }

        /// <summary>Seos mänguga.</summary>
        public Match Match { get; set; }

        /// <summary>Ennustuse teinud kasutaja.</summary>
        public int UserId { get; set; }

        /// <summary>Seos kasutajaga.</summary>
        public User User { get; set; }
    }
}
