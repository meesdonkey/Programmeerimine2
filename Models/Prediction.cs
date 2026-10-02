namespace FootballPredictions.Models;

public class Prediction
{
    public int Id { get; set; }

    public int Team1Score { get; set; }
    public int Team2Score { get; set; }

    public int Points { get; set; }

    public int MatchId { get; set; }
    public int UserId { get; set; }
}