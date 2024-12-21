using Microsoft.AspNetCore.Mvc;
using TournamentApp.MapperProfile;

namespace TournamentApp.controller;

public class TeamController
{
    private ITeamRepository _teamRepository;

    public TeamController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
}