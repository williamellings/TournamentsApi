using Microsoft.EntityFrameworkCore;
using TournamentsApi.Data;
using TournamentsApi.Dtos;
using TournamentsApi.Models;

namespace TournamentsApi.Services;

public class TournamentService : ITournamentService
{
    private readonly AppDbContext _context;

    public TournamentService(AppDbContext context) => _context = context;

    public async Task<IEnumerable<TournamentResponseDto>> GetAllAsync(string? search)
    {
        var query = _context.Tournaments.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(t => t.Title.Contains(search));
        }

        return await query.Select(t => new TournamentResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            MaxPlayers = t.MaxPlayers,
            Date = t.Date
        }).ToListAsync();
    }

    public async Task<TournamentResponseDto?> GetByIdAsync(int id)
    {
        var t = await _context.Tournaments.FindAsync(id);
        if (t == null) return null;

        return new TournamentResponseDto
        {
            Id = t.Id,
            Title = t.Title,
            MaxPlayers = t.MaxPlayers,
            Date = t.Date
        };
    }

    public async Task<TournamentResponseDto> CreateAsync(TournamentCreateDto dto)
    {
        var tournament = new Tournament
        {
            Title = dto.Title,
            Description = dto.Description,
            MaxPlayers = dto.MaxPlayers,
            Date = dto.Date
        };

        _context.Tournaments.Add(tournament);
        await _context.SaveChangesAsync();

        return new TournamentResponseDto
        {
            Id = tournament.Id,
            Title = tournament.Title,
            MaxPlayers = tournament.MaxPlayers,
            Date = tournament.Date
        };
    }

    public async Task<bool> UpdateAsync(int id, TournamentUpdateDto dto)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return false;

        tournament.Title = dto.Title;
        tournament.Description = dto.Description;
        tournament.MaxPlayers = dto.MaxPlayers;
        tournament.Date = dto.Date;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tournament = await _context.Tournaments.FindAsync(id);
        if (tournament == null) return false;

        _context.Tournaments.Remove(tournament);
        await _context.SaveChangesAsync();
        return true;
    }
}