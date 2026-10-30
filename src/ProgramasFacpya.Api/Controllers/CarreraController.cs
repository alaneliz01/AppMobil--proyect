using Microsoft.AspNetCore.Mvc;
using ProgramasFacpya.Api.Features.Carreras;
using ProgramasFacpya.Api.Features.Carreras.Dominio.Dto;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarreraController(CarreraService service) : ControllerBase
{
    private readonly CarreraService _service = service;

    [HttpGet("ObtenerTodoCarrera")]
    public async Task<IActionResult> ObtenerTodoCarrera()
    {
        return Ok(await _service.ObtenerTodos());
    }

    [HttpGet("ObtenerPorIdCarrera/{idCarrera:int}")]
    public async Task<IActionResult> ObtenerPorIdCarrera(int idCarrera)
    {
        return Ok(await _service.ObtenerPorId(idCarrera));
    }

    [HttpPost("CrearCarrera")]
    public async Task<IActionResult> CrearCarrera([FromBody] CarreraDTO dto)
    {
        return Ok(await _service.Crear(dto));
    }

    [HttpPut("ModificarCarrera/{idCarrera:int}")]
    public async Task<IActionResult> ModificarCarrera(int idCarrera, [FromBody] CarreraDTO dto)
    {
        return Ok(await _service.Actualizar(idCarrera, dto));
    }

    [HttpDelete("EliminarCarrera/{idCarrera:int}")]
    public async Task<IActionResult> EliminarCarrera(int idCarrera)
    {
        return Ok(await _service.Eliminar(idCarrera));
    }
}
