using Microsoft.AspNetCore.Mvc;
using ProgramasFacpya.Api.Features.Alumnos;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController(AlumnoService service) : ControllerBase
{
    private readonly AlumnoService _service = service;
    // Tipos de cambio de referencia (aprox. octubre 2026)
    private const double PesosPorDolar = 18.66;
    private const double PesosPorEuro = 21.65;

    [HttpGet("ObtenerTodos")]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _service.ObtenerTodos());
    }

    [HttpGet("ObtenerPorId/{idAlumno:int}")]
    public async Task<IActionResult> ObtenerPorId(int idAlumno)
    {
        return Ok(await _service.ObtenerPorId(idAlumno));
    }

    [HttpPost("Crear")]
    public async Task<IActionResult> Crear([FromBody] AlumnoDTO dto)
    {
        return Ok(await _service.Crear(dto));
    }

    [HttpPut("Actualizar/{idAlumno:int}")]
    public async Task<IActionResult> Actualizar(int idAlumno, [FromBody] AlumnoDTO dto)
    {
        return Ok(await _service.Actualizar(idAlumno, dto));
    }

    [HttpDelete("Eliminar/{idAlumno:int}")]
    public async Task<IActionResult> Eliminar(int idAlumno)
    {
        return Ok(await _service.Eliminar(idAlumno));
    }

}