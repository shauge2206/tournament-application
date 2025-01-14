using AutoMapper;
using TournamentApp.Domain;
using TournamentApp.DTO;
using TournamentApp.DTO.Player;
using TournamentApp.DTO.Team;
using TournamentApp.Model;

namespace TournamentApp.MapperProfile;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        // DTO to Entity (PlayerModel)
        CreateMap<AddPlayerDto, PlayerModel>();
        CreateMap<UpdatePlayerDto, PlayerModel>();

        // Entity (PlayerModel) to Domain (Player)
        CreateMap<PlayerModel, Player>();
        CreateMap<Player, PlayerModel>();

        // DTO to Domain (Player)
        CreateMap<AddPlayerDto, Player>();
        CreateMap<UpdatePlayerDto, Player>();

        // Domain (Player) to Response DTO (PlayerResponseDto)
        CreateMap<Player, PlayerResponseDto>()
            .ForMember(dest => 
                dest.TeamName, opt => 
                opt.MapFrom(
                    src => src.Team != null ? src.Team.Name : null));
        
        CreateMap<TeamModel, Team>();
        CreateMap<Team, TeamResponseDto>();
        CreateMap<AddTeamDto, Team>();
        CreateMap<Team, TeamModel>();
    }
}