using AutoMapper;
using TournamentApp.Domain;
using TournamentApp.DTO;
using TournamentApp.DTO.Player;
using TournamentApp.Model;

namespace TournamentApp.MapperProfile;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<AddPlayerDto, PlayerModel>();
        CreateMap<UpdatePlayerDto, PlayerModel>();
        CreateMap<PlayerModel, Player>();
        CreateMap<AddPlayerDto, PlayerModel>();
        CreateMap<AddPlayerDto, Player>();
        CreateMap<UpdatePlayerDto, PlayerModel>();
        CreateMap<Player, PlayerModel>();
        CreateMap<Player, PlayerResponseDto>();
    }
}