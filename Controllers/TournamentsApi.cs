using Microsoft.AspNetCore.Mvc;
using TournamentsApi.Dtos;
using TournamentsApi.Services;

namespace TournamentsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;

    public TournamentsController(ITournamentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TournamentResponseDto>>> GetAll([FromQuery] string? search)
    {
        return Ok(await _service.GetAllAsync(search));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TournamentResponseDto>> Get(int id)
    {
        var result = await _service.GetByIdAsync(id);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<TournamentResponseDto>> Create(TournamentCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TournamentUpdateDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}