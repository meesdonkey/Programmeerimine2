using FootballPredictions.Models;

Tournament tournament = new Tournament
{
    Id = 1,
    Name = "Champions League"
};

Team team1 = new Team
{
    Id = 1,
    Name = "Barcelona"
};

Team team2 = new Team
{
    Id = 2,
    Name = "Real Madrid"
};

User user = new User
{
    Id = 1,
    UserName = "Joao",
    Password = "1234"
};

Match match = new Match
{
    Id = 1,
    Date = DateTime.Now,
    TournamentId = tournament.Id,
    Team1Id = team1.Id,
    Team2Id = team2.Id,
    Team1Score = 2,
    Team2Score = 1,
    RoundId = 1
};

Prediction prediction = new Prediction
{
    Id = 1,
    Team1Score = 2,
    Team2Score = 1,
    Points = 3,
    MatchId = match.Id,
    UserId = user.Id
};

Scoreboard scoreboard = new Scoreboard
{
    Id = 1,
    TournamentId = tournament.Id,
    UserId = user.Id,
    Score = prediction.Points
};

Console.WriteLine($"{team1.Name} {match.Team1Score}:{match.Team2Score} {team2.Name}");
Console.WriteLine($"{user.UserName} predicted {prediction.Team1Score}:{prediction.Team2Score}");
Console.WriteLine($"Points: {scoreboard.Score}");