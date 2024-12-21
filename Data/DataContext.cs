using Microsoft.EntityFrameworkCore;
using TournamentApp.Model;

namespace TournamentApp.Data;

public class DataContext : DbContext
{
    public DbSet<PlayerModel> Players { get; set; }

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
    }
}