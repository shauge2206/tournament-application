namespace TournamentApp.Model;

public class PrizeModel
{
    public required string PlaceName { get; init; }
    public int PrizeAmount { get; init; }
    public required string PlaceNumber { get; init; }
    public required string PrizePercent { get; init; }
}