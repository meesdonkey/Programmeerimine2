namespace FootballPredictions.Models;

public class Match
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int TournamentId { get; set; }
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }

    public int Team1Score { get; set; }
    public int Team2Score { get; set; }

    public int RoundId { get; set; }
}