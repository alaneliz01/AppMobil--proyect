using Microsoft.AspNetCore.Mvc;
namespace ProgramasFacpya.Api.Controllers;
using BL_ALUMNO = ProgramasFacpya.Api.Servicios.BL_ALUMNO;
using ProgramasFacpya.Api.Models;
[ApiController]
[Route("api/[controller]")]
public class Alumnos : ControllerBase
{
    [HttpPost("RegistroAlumnos")]
    public IActionResult RegistroAlumnos([FromBody] ALUMNO2 Alumno)
    {
        List<string> lstErrores = BL_ALUMNO.Validaciones(Alumno.Nombre, Alumno.APaterno, Alumno.AMaterno);
        
        if (lstErrores.Count == 0)
        {
            return Ok(new
            {
                code = "00",
                value = "",
                msg = "Operación completada exitosamente"
            });
        }
        else
        {
            return Ok(new
            {
                code = "01",
                value = lstErrores,
                msg = "Se encontraron errores en la validación",
                errors = lstErrores
            });
        }

    }
}
