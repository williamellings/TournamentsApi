using Microsoft.EntityFrameworkCore;
using TournamentsApi.Models;
using System;

namespace TournamentsApi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Game> Games { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var tournamentDate = new DateTime(2026, 03, 19, 10, 0, 0);

        modelBuilder.Entity<Tournament>().HasData(
            new Tournament
            {
                Id = 1,
                Title = "GG Masters",
                Description = "Biggest Esport event in the world.",
                MaxPlayers = 64,
                Date = tournamentDate
            }
        );

        modelBuilder.Entity<Game>().HasData(
            new Game { Id = 1, Title = "Quarter finals A", Time = tournamentDate.AddHours(2), TournamentId = 1 },
            new Game { Id = 2, Title = "Quarter finals B", Time = tournamentDate.AddHours(4), TournamentId = 1 }
        );
    } 
}