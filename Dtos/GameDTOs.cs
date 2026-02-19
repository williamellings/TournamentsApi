using System.ComponentModel.DataAnnotations;

namespace TournamentsApi.Dtos;

public class GameCreateDto
{
    [Required, MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public DateTime Time { get; set; }
    [Required]
    public int TournamentId { get; set; }
}

public class GameResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Time { get; set; }
    public int TournamentId { get; set; }

    public List<GameResponseDto> Games { get; set; } = new();
}