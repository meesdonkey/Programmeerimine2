using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Üks jalgpallimäng kahe võistkonna vahel kindlal turniiril.
    /// </summary>
    public class Match
    {
        /// <summary>Mängu unikaalne identifikaator.</summary>
        public int Id { get; set; }

        /// <summary>Mängu algusaeg.</summary>
        public DateTime Date { get; set; }

        /// <summary>Turniir, mille raames mäng peetakse.</summary>
        public int TournamentId { get; set; }

        /// <summary>Seos turniiriga.</summary>
        public Tournament Tournament { get; set; }

        /// <summary>Kodu- või esimese võistkonna identifikaator.</summary>
        public int Team1Id { get; set; }

        /// <summary>Esimene võistkond.</summary>
        public Team Team1 { get; set; }

        /// <summary>Külalis- või teise võistkonna identifikaator.</summary>
        public int Team2Id { get; set; }

        /// <summary>Teine võistkond.</summary>
        public Team Team2 { get; set; }

        /// <summary>Esimese võistkonna lõppskoor.</summary>
        public int Team1Score { get; set; }

        /// <summary>Teise võistkonna lõppskoor.</summary>
        public int Team2Score { get; set; }

        /// <summary>Vooru number turniiri sees, näiteks 1 on avavoor.</summary>
        public int RoundId { get; set; }

        /// <summary>Sellele mängule tehtud ennustused.</summary>
        public IList<Prediction> Predictions { get; set; } = new List<Prediction>();
    }
}
