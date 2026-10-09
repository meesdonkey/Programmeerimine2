using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Täidab tühja andmebaasi jalgpalli ennustusmängu algandmetega.
    /// Igas tabelis on vähemalt 35 rida.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Lisab algandmed ainult siis, kui kasutajaid veel pole.
        /// Korduv käivitus olemasoleva andmebaasiga ridu ei dubleeri.
        /// </summary>
        public static void EnsureSeedData(this ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = CreateUsers();
            var teams = CreateTeams();
            var tournaments = CreateTournaments();

            context.Users.AddRange(users);
            context.Teams.AddRange(teams);
            context.Tournaments.AddRange(tournaments);
            context.SaveChanges();

            var matches = CreateMatches(teams, tournaments);
            context.Matches.AddRange(matches);
            context.SaveChanges();

            var predictions = CreatePredictions(users, matches);
            context.Predictions.AddRange(predictions);
            context.SaveChanges();

            context.Scoreboards.AddRange(CreateScoreboards(predictions));
            context.SaveChanges();
        }

        private static List<User> CreateUsers()
        {
            string[] names =
            {
                "joao.silva", "alexander.ehte", "mari.tamm", "karl.kask", "liis.saar",
                "mart.sepp", "anna.magi", "jaanus.koppel", "kadri.ilves", "rasmus.parn",
                "helena.rebane", "markus.lepp", "katlin.kallas", "oliver.vaher", "laura.poder",
                "sander.kuusk", "getter.oja", "henri.kivi", "brigitte.laur", "kristjan.mets",
                "eva.lind", "taavi.nurk", "triin.kalda", "robin.aas", "grete.puusepp",
                "andreas.teder", "maria.kukk", "kevin.raud", "sandra.allik", "martin.kaar",
                "eliise.soo", "jurgen.palm", "katariina.veski", "priit.laan", "anneli.molder",
                "toomas.kruus"
            };

            var users = new List<User>();
            for (var i = 0; i < names.Length; i++)
            {
                users.Add(new User
                {
                    UserName = names[i],
                    Password = "Vahe." + (2020 + (i % 7))
                });
            }

            return users;
        }

        private static List<Team> CreateTeams()
        {
            string[] names =
            {
                "Arsenal", "Manchester City", "Liverpool", "Chelsea", "Manchester United",
                "Tottenham Hotspur", "Newcastle United", "Aston Villa", "Brighton", "West Ham United",
                "Real Madrid", "Barcelona", "Atletico Madrid", "Athletic Bilbao", "Real Sociedad",
                "Villarreal", "Sevilla", "Real Betis", "Inter", "AC Milan",
                "Juventus", "Napoli", "Roma", "Lazio", "Atalanta",
                "Fiorentina", "Bayern Munich", "Borussia Dortmund", "RB Leipzig", "Bayer Leverkusen",
                "Eintracht Frankfurt", "Paris Saint-Germain", "Marseille", "Monaco", "Lille",
                "Lyon"
            };

            var teams = new List<Team>();
            foreach (var name in names)
            {
                teams.Add(new Team { Name = name });
            }

            return teams;
        }

        private static List<Tournament> CreateTournaments()
        {
            string[] names =
            {
                "Premier League 2024/25", "Premier League 2025/26", "La Liga 2024/25", "La Liga 2025/26",
                "Serie A 2024/25", "Serie A 2025/26", "Bundesliga 2024/25", "Bundesliga 2025/26",
                "Ligue 1 2024/25", "Ligue 1 2025/26", "UEFA Champions League 2024/25", "UEFA Champions League 2025/26",
                "UEFA Europa League 2024/25", "UEFA Europa League 2025/26", "UEFA Conference League 2024/25",
                "FA Cup 2024/25", "FA Cup 2025/26", "Copa del Rey 2024/25", "Coppa Italia 2024/25",
                "DFB-Pokal 2024/25", "Coupe de France 2024/25", "Eredivisie 2024/25", "Primeira Liga 2024/25",
                "Scottish Premiership 2024/25", "Süper Lig 2024/25", "Belgian Pro League 2024/25",
                "UEFA European Championship 2024", "FIFA World Cup 2026", "UEFA Nations League 2024/25",
                "Community Shield 2025", "UEFA Super Cup 2025", "FIFA Club World Cup 2025",
                "Premium Liiga 2025", "Premium Liiga 2026", "Eesti karikas 2025", "UEFA Champions League 2023/24"
            };

            var tournaments = new List<Tournament>();
            foreach (var name in names)
            {
                tournaments.Add(new Tournament { Name = name });
            }

            return tournaments;
        }

        private static List<Match> CreateMatches(IReadOnlyList<Team> teams, IReadOnlyList<Tournament> tournaments)
        {
            // Team1, Team2, Tournament, year, month, day, score1, score2
            var plans = new (int Team1, int Team2, int Tournament, int Year, int Month, int Day, int Score1, int Score2)[]
            {
                (10, 27, 35, 2024, 6, 1, 2, 0),
                (31, 18, 10, 2025, 5, 31, 5, 0),
                (11, 10, 2, 2024, 10, 26, 0, 3),
                (0, 2, 0, 2024, 10, 27, 2, 2),
                (1, 4, 0, 2024, 11, 2, 1, 2),
                (3, 5, 0, 2024, 11, 10, 2, 1),
                (6, 7, 0, 2024, 11, 16, 1, 1),
                (8, 9, 0, 2024, 11, 23, 3, 1),
                (12, 13, 2, 2024, 12, 1, 1, 0),
                (14, 15, 2, 2024, 12, 8, 2, 2),
                (16, 17, 2, 2024, 12, 15, 0, 1),
                (18, 19, 4, 2024, 12, 22, 2, 1),
                (20, 21, 4, 2025, 1, 5, 1, 1),
                (22, 23, 4, 2025, 1, 12, 3, 0),
                (24, 25, 4, 2025, 1, 19, 2, 2),
                (26, 29, 6, 2025, 1, 26, 1, 0),
                (28, 30, 6, 2025, 2, 2, 2, 1),
                (32, 33, 8, 2025, 2, 9, 1, 1),
                (34, 35, 8, 2025, 2, 16, 2, 0),
                (2, 1, 0, 2025, 2, 23, 2, 0),
                (4, 0, 0, 2025, 3, 2, 1, 1),
                (5, 3, 16, 2025, 3, 9, 0, 2),
                (7, 6, 0, 2025, 3, 16, 3, 2),
                (9, 8, 0, 2025, 3, 30, 1, 2),
                (10, 11, 2, 2025, 4, 6, 3, 2),
                (13, 12, 17, 2025, 4, 13, 0, 1),
                (15, 14, 2, 2025, 4, 20, 2, 1),
                (17, 16, 2, 2025, 4, 27, 1, 1),
                (19, 18, 18, 2025, 5, 4, 0, 2),
                (21, 20, 4, 2025, 5, 11, 3, 1),
                (23, 22, 4, 2025, 5, 18, 2, 2),
                (25, 24, 4, 2025, 8, 17, 1, 0),
                (29, 26, 6, 2025, 8, 24, 2, 2),
                (30, 28, 19, 2025, 9, 7, 1, 3),
                (33, 32, 8, 2025, 9, 14, 0, 2),
                (35, 34, 8, 2025, 9, 21, 1, 1),
                (0, 1, 1, 2025, 10, 5, 1, 1),
                (11, 12, 3, 2025, 10, 19, 2, 0),
                (18, 20, 11, 2025, 11, 2, 4, 1),
                (26, 27, 11, 2025, 11, 9, 3, 1)
            };

            var matches = new List<Match>();
            for (var i = 0; i < plans.Length; i++)
            {
                var plan = plans[i];
                var tournament = tournaments[plan.Tournament];
                matches.Add(new Match
                {
                    Team1 = teams[plan.Team1],
                    Team1Id = teams[plan.Team1].Id,
                    Team2 = teams[plan.Team2],
                    Team2Id = teams[plan.Team2].Id,
                    Tournament = tournament,
                    TournamentId = tournament.Id,
                    Date = new DateTime(plan.Year, plan.Month, plan.Day, 18, 0, 0),
                    Team1Score = plan.Score1,
                    Team2Score = plan.Score2,
                    RoundId = (i % 12) + 1
                });
            }

            return matches;
        }

        private static List<Prediction> CreatePredictions(IReadOnlyList<User> users, IReadOnlyList<Match> matches)
        {
            var predictions = new List<Prediction>();
            for (var i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var predicted1 = match.Team1Score;
                var predicted2 = match.Team2Score;

                if (i % 3 == 1)
                {
                    predicted1 = Math.Max(0, predicted1 - 1);
                }
                else if (i % 3 == 2)
                {
                    predicted2 = predicted2 + 1;
                }

                var user = users[i % users.Count];
                predictions.Add(new Prediction
                {
                    User = user,
                    UserId = user.Id,
                    Match = match,
                    MatchId = match.Id,
                    Team1Score = predicted1,
                    Team2Score = predicted2,
                    Points = CalculatePoints(predicted1, predicted2, match.Team1Score, match.Team2Score)
                });
            }

            return predictions;
        }

        private static List<Scoreboard> CreateScoreboards(IEnumerable<Prediction> predictions)
        {
            return predictions
                .GroupBy(prediction => new { prediction.UserId, prediction.Match.TournamentId })
                .Select(group => new Scoreboard
                {
                    UserId = group.Key.UserId,
                    TournamentId = group.Key.TournamentId,
                    Score = group.Sum(prediction => prediction.Points)
                })
                .ToList();
        }

        /// <summary>
        /// 5 punkti täpse skoori eest, 2 punkti õige tulemuse (võit või viik) eest.
        /// </summary>
        private static int CalculatePoints(int predicted1, int predicted2, int actual1, int actual2)
        {
            if (predicted1 == actual1 && predicted2 == actual2)
            {
                return 5;
            }

            var predictedOutcome = Math.Sign(predicted1 - predicted2);
            var actualOutcome = Math.Sign(actual1 - actual2);
            if (predictedOutcome == actualOutcome)
            {
                return 2;
            }

            return 0;
        }
    }
}
