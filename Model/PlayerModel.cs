using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournamentApp.Model;

[Table("Players")]
public class PlayerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    [StringLength(20, MinimumLength = 3)]
    public required string NickName { get; set; }
    
    public string? Telephone { get; set; }
    
    [ForeignKey("TeamId")]
    public Guid? TeamId { get; set; }
    //Navigation property:
    public TeamModel? Team { get; set; }
    //Not strictly needed. Beneficial for loading of related data, mapping with automapper and other worthy benefits.
    
    
}