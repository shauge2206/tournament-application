using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentApp.Domain;
using TournamentApp.DTO;
using TournamentApp.DTO.Player;
using TournamentApp.Interface.Player;
using TournamentApp.Model;

namespace TournamentApp.controller;

[ApiController]
[Route("/api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;
    private readonly IMapper _mapper;
    
    public PlayerController(IPlayerService playerService, IMapper mapper)
    { 
        _playerService = playerService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<PlayerResponseDto>>> GetPlayers()
    {
        var players =  await _playerService.GetAllPlayers();
        return Ok(_mapper.Map<List<PlayerResponseDto>>(players));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PlayerResponseDto>> GetPlayerById(Guid id)
    {
         var player = await _playerService.GetPlayer(id);
         return Ok(_mapper.Map<PlayerResponseDto>(player));
    }
    
    [HttpPost]
    public async Task<ActionResult<PlayerResponseDto>> CreatePlayer([FromBody] AddPlayerDto addPlayerDto)
    {
        var newPlayer = await _playerService.CreatePlayer(addPlayerDto);
        return Ok(_mapper.Map<PlayerResponseDto>(newPlayer));
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<PlayerResponseDto>> UpdatePlayer(Guid id,
        [FromBody] UpdatePlayerDto updatePlayerDto)
    {
        Player updatedPlayer = await _playerService.UpdatePlayer(id, updatePlayerDto);
        return Ok(_mapper.Map<PlayerResponseDto>(updatedPlayer));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<PlayerResponseDto>> DeletePlayer(Guid id)
    {
        var deletedPlayer = await _playerService.DeletePlayer(id);
        return Ok(_mapper.Map<PlayerResponseDto>(deletedPlayer));
    }
}