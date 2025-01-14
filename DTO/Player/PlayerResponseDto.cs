namespace TournamentApp.DTO.Player;

public class PlayerResponseDto
{
    public required string NickName { get; init; }
    public string? Telephone { get; init; }
    public string? TeamName { get; init; }
}