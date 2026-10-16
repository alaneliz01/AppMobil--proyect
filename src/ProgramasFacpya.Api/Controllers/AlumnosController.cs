using Microsoft.AspNetCore.Mvc;
using ProgramasFacpya.Api.Features.Alumnos;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController(AlumnoService service) : ControllerBase
{
    private readonly AlumnoService _service = service;

    [HttpGet("ObtenerTodos")]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _service.ObtenerTodos());
    }
}