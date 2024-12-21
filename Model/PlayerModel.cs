using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentApp.Model;

[Table("Players")]
public class PlayerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [MaxLength(20)]
    public required string NickName { get; init; }
    
    public string? Telephone { get; init; }
}