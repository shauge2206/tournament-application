using System.ComponentModel.DataAnnotations;
using TournamentApp.Validation;

namespace TournamentApp.Domain;

public class Player
{
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Nickname must be between 3 and 20 characters.")]
    public string NickName { get; set; }
    
    [DigitsOnly(ErrorMessage = "Telephone must can only contain numbers.")]
    public string? Telephone { get; set; }

    public Player(string nickName, string? telephone)
    {
        if (string.IsNullOrWhiteSpace(nickName))
            throw new ArgumentException($"'{nameof(nickName)}' cannot be null or whitespace", nameof(nickName));
        
        NickName = nickName;
        Telephone = telephone;
    }

    public void UpdateNickName(string newNickName)
    {
        if (string.IsNullOrWhiteSpace(newNickName))
            throw new ArgumentException($"'{nameof(newNickName)}' updated nick name cannot be null or whitespace", nameof(newNickName));
        
        NickName = newNickName;
    }

    public void UpdateTelephone(string newTelephone)
    {
        
        if (string.IsNullOrWhiteSpace(newTelephone))
            throw new ArgumentException($"'{nameof(newTelephone)}' updated telephone number cannot be null or whitespace", nameof(newTelephone));
        
        Telephone = newTelephone;
    }
}