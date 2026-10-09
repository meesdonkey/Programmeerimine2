namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Jalgpalliklubi või koondis, mis osaleb mängudes.
    /// </summary>
    public class Team
    {
        /// <summary>Võistkonna unikaalne identifikaator.</summary>
        public int Id { get; set; }

        /// <summary>Võistkonna nimi, näiteks Barcelona või Liverpool.</summary>
        public string Name { get; set; } = string.Empty;
    }
}
