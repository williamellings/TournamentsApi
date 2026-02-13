using TournamentsApi.Dtos;

namespace TournamentsApi.Services;

public interface ITournamentService
{
    Task<IEnumerable<TournamentResponseDto>> GetAllAsync(string? search);
    Task<TournamentResponseDto?> GetByIdAsync(int id);
    Task<TournamentResponseDto> CreateAsync(TournamentCreateDto dto);
    Task<bool> UpdateAsync(int id, TournamentUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}