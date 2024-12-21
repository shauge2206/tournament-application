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
    public async Task<ActionResult<List<Player>>> GetPlayers()
    {
        var players =  await _playerService.GetAllPlayers();
        return Ok(_mapper.Map<List<PlayerResponseDto>>(players));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PlayerModel?>> GetPlayerById(Guid id)
    {
         var player = await _playerService.GetPlayer(id);
         return Ok(_mapper.Map<PlayerResponseDto>(player));
    }
    
    [HttpPost]
    public async Task<ActionResult<PlayerModel?>> CreatePlayer([FromBody] AddPlayerDto addPlayerDto)
    {
        var createdPlayer = await _playerService.CreatePlayer(addPlayerDto);
        return Ok(_mapper.Map<PlayerResponseDto>(createdPlayer));
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<PlayerModel?>> UpdatePlayer(Guid id,
        [FromBody] UpdatePlayerDto updatePlayerDto)
    {
        Player updatedPlayer = await _playerService.UpdatePlayer(id, updatePlayerDto);
        return Ok(_mapper.Map<PlayerResponseDto>(updatedPlayer));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<PlayerModel?>> DeletePlayer(Guid id)
    {
        var deletedPlayer = await _playerService.DeletePlayer(id);
        return Ok(_mapper.Map<PlayerResponseDto>(deletedPlayer));
    }
}