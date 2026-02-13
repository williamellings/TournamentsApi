using Microsoft.EntityFrameworkCore;
using TournamentsApi.Models;

namespace TournamentsApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tournament> Tournaments => Set<Tournament>();
}