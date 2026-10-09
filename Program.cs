using KooliProjekt.Application.Data;

Tournament tournament = new Tournament
{
    Name = "UEFA Champions League 2024/25"
};

Team team1 = new Team
{
    Name = "Barcelona"
};

Team team2 = new Team
{
    Name = "Real Madrid"
};

User user = new User
{
    UserName = "joao.silva",
    Password = "Vahe.2024"
};

Match match = new Match
{
    Date = DateTime.Now,
    Tournament = tournament,
    Team1 = team1,
    Team2 = team2,
    Team1Score = 2,
    Team2Score = 1,
    RoundId = 1
};

Prediction prediction = new Prediction
{
    Team1Score = 2,
    Team2Score = 1,
    Points = 5,
    Match = match,
    User = user
};

Scoreboard scoreboard = new Scoreboard
{
    Tournament = tournament,
    User = user,
    Score = prediction.Points
};

Console.WriteLine($"{team1.Name} {match.Team1Score}:{match.Team2Score} {team2.Name}");
Console.WriteLine($"{user.UserName} predicted {prediction.Team1Score}:{prediction.Team2Score}");
Console.WriteLine($"Points: {scoreboard.Score}");
