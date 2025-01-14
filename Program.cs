using Microsoft.EntityFrameworkCore;
using TournamentApp.Data;
using TournamentApp.Interface;
using TournamentApp.Interface.Player;
using TournamentApp.Interface.Team;
using TournamentApp.MapperProfile;
using TournamentApp.Repository;
using TournamentApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddAutoMapper(typeof(PlayerProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Add DataContext class to be handled by the DI container
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();