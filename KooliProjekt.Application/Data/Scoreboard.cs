namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Kasutaja kogupunktid ühel turniiril. Ühel kasutajal on turniiri kohta üks rida.
    /// </summary>
    public class Scoreboard
    {
        /// <summary>Punktiseisu unikaalne identifikaator.</summary>
        public int Id { get; set; }

        /// <summary>Turniir, mille punkte rida koondab.</summary>
        public int TournamentId { get; set; }

        /// <summary>Seos turniiriga.</summary>
        public Tournament Tournament { get; set; }

        /// <summary>Kasutaja, kelle punktid need on.</summary>
        public int UserId { get; set; }

        /// <summary>Seos kasutajaga.</summary>
        public User User { get; set; }

        /// <summary>Kasutaja punktisumma sellel turniiril.</summary>
        public int Score { get; set; }
    }
}
