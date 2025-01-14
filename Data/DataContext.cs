using Microsoft.EntityFrameworkCore;
using TournamentApp.Model;

namespace TournamentApp.Data;

public class DataContext : DbContext
{
    public DbSet<PlayerModel> Players { get; set; }
    public DbSet<TeamModel> Teams { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Enable sensitive data logging
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add seed data for the Players table
        modelBuilder.Entity<PlayerModel>().HasData(
            new PlayerModel { Id = new Guid("4fa85f64-5717-4562-b3fc-2c963f66afa6"), NickName = "Tex", Telephone = "29394003" },
            new PlayerModel { Id = new Guid("6fa85f64-5717-4562-b3fc-2c963f66afa6"), NickName = "Morty", Telephone = "29303930" },
            new PlayerModel { Id = new Guid("8fa85f64-5717-4562-b3fc-2c963f66afa6"), NickName = "Pablo", Telephone = "92826262" }
        );
        
        // Add seed data for the Teams table
        modelBuilder.Entity<TeamModel>().HasData(
            new TeamModel
            {
                TeamId = new Guid("1fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Alpha Team",
                MaxPlayers = 10,
                MinPlayers = 5,
                Players = []
            },
            new TeamModel
            {
                TeamId = new Guid("2fa85f64-5717-4562-b3fc-2c963f66afa6"),
                Name = "Beta Squad",
                MaxPlayers = 8,
                MinPlayers = 3,
                Players = []
            }
        );
    }
}