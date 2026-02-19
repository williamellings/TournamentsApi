using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using TournamentsApi.Dtos;
using TournamentsApi.Services;

namespace TournamentsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TournamentsController : ControllerBase
{
    private readonly ITournamentService _service;

    // we inject the service layer into the controller via constructor injection, following the Dependency Injection pattern. This allows for better separation of concerns and easier testing.
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
    [EnableRateLimiting("strict")] // Sfety measure to prevent abuse of the create endpoint
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

    [HttpPatch("{id}/title")] // update only the title of the tournament
    public async Task<IActionResult> PatchTitle(int id, [FromBody] string newTitle)
    {
        var success = await _service.UpdateTitleAsync(id, newTitle);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [Authorize] 
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}