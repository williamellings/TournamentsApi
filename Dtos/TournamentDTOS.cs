using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace TournamentsApi.Dtos;

public class TournamentCreateDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public int MaxPlayers { get; set; }

    [Required]
    [FutureDate(ErrorMessage = "Date cannot be in the past.")]
    public DateTime Date { get; set; }
}

public class TournamentUpdateDto : TournamentCreateDto { }

public class TournamentResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int MaxPlayers { get; set; }
    public DateTime Date { get; set; }
    public List<GameResponseDto> Games { get; set; } = new List<GameResponseDto>();
}

public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is DateTime dateTime && dateTime >= DateTime.Now;
    }
}