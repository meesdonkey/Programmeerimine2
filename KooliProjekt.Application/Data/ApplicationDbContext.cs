using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Data
{
    /// <summary>
    /// Rakenduse andmebaasikontekst. Siin on kõik tabelid, mida Entity Framework Core haldab.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>Kasutajad.</summary>
        public DbSet<User> Users { get; set; }

        /// <summary>Võistkonnad.</summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>Turniirid ja liigahooajad.</summary>
        public DbSet<Tournament> Tournaments { get; set; }

        /// <summary>Mängud.</summary>
        public DbSet<Match> Matches { get; set; }

        /// <summary>Kasutajate ennustused.</summary>
        public DbSet<Prediction> Predictions { get; set; }

        /// <summary>Punktitabelid turniiri ja kasutaja kaupa.</summary>
        public DbSet<Scoreboard> Scoreboards { get; set; }

        /// <summary>
        /// Seab välisvõtmed ja kustutamisreeglid. SQL Server ei luba mitut kaskaadteed,
        /// seepärast on seotud tabelite kustutamine piiratud.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(user => user.UserName).HasMaxLength(50).IsRequired();
                entity.Property(user => user.Password).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(team => team.Name).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(tournament => tournament.Name).HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasOne(match => match.Tournament)
                    .WithMany(tournament => tournament.Matches)
                    .HasForeignKey(match => match.TournamentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(match => match.Team1)
                    .WithMany()
                    .HasForeignKey(match => match.Team1Id)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(match => match.Team2)
                    .WithMany()
                    .HasForeignKey(match => match.Team2Id)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Prediction>(entity =>
            {
                entity.HasOne(prediction => prediction.Match)
                    .WithMany(match => match.Predictions)
                    .HasForeignKey(prediction => prediction.MatchId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(prediction => prediction.User)
                    .WithMany(user => user.Predictions)
                    .HasForeignKey(prediction => prediction.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Scoreboard>(entity =>
            {
                entity.HasIndex(scoreboard => new { scoreboard.UserId, scoreboard.TournamentId }).IsUnique();

                entity.HasOne(scoreboard => scoreboard.Tournament)
                    .WithMany(tournament => tournament.Scoreboards)
                    .HasForeignKey(scoreboard => scoreboard.TournamentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(scoreboard => scoreboard.User)
                    .WithMany(user => user.Scoreboards)
                    .HasForeignKey(scoreboard => scoreboard.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
