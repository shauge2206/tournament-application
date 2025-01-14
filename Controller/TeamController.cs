using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.DTO.Team;
using TournamentApp.Interface.Team;

namespace TournamentApp.controller;

[ApiController]
[Route("/api/[controller]")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;
    private readonly IMapper _mapper;

    public TeamController(ITeamService teamService, IMapper mapper)
    {
        _teamService = teamService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<TeamResponseDto>>> GetPlayers()
    {
        var teams =  await _teamService.GetAllTeams();
        return Ok(_mapper.Map<List<TeamResponseDto>>(teams));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TeamResponseDto>> GetTeamById(Guid id)
    {
        var player = await _teamService.GetTeam(id);
        return Ok(_mapper.Map<TeamResponseDto>(player));
    }
    
    [HttpPost]
    public async Task<ActionResult<TeamResponseDto>> CreateTeam([FromBody] AddTeamDto addTeamDto)
    {
        var newTeam = await _teamService.CreateTeam(addTeamDto);
        return Ok(_mapper.Map<TeamResponseDto>(newTeam));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<TeamResponseDto>> DeleteTeam(Guid id)
    {
        var deletedPlayer = await _teamService.DeleteTeam(id);
        return Ok(_mapper.Map<TeamResponseDto>(deletedPlayer));
    }
    
    [HttpPost("{teamId:guid}/players/{playerId:guid}")]
    public async Task<ActionResult<TeamResponseDto>> AddPlayerToTeam(Guid teamId, Guid playerId)
    {
        var team = await _teamService.AddPlayerToTeam(teamId, playerId);
        return Ok(_mapper.Map<TeamResponseDto>(team));
    }
    
    [HttpDelete("{teamId:guid}/players/{playerId:guid}")]
    public async Task<ActionResult<TeamResponseDto>> RemovePlayerToTeam(Guid teamId, Guid playerId)
    {
        var team = await _teamService.RemovePlayerFromTeam(teamId, playerId);
        return Ok(_mapper.Map<TeamResponseDto>(team));
    }
}