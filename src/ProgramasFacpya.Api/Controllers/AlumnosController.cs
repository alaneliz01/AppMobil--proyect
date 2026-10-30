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

    // Ejercicio 1: Sumar 2 números
    [HttpGet("Suma/{num1:double}/{num2:double}")]
    public IActionResult Suma(double num1, double num2)
    {
        return Ok($"La suma es: {num1 + num2}");
    }

    // Ejercicio 2: Restar 2 números
    [HttpGet("Resta/{num1:double}/{num2:double}")]
    public IActionResult Resta(double num1, double num2)
    {
        return Ok($"La resta es: {num1 - num2}");
    }

    // Ejercicio 3: Multiplicar 2 números
    [HttpGet("Multiplicacion/{num1:double}/{num2:double}")]
    public IActionResult Multiplicacion(double num1, double num2)
    {
        return Ok($"La multiplicación es: {num1 * num2}");
    }

    // Ejercicio 4: Promedio de 3 calificaciones
    [HttpGet("Promedio/{cal1:double}/{cal2:double}/{cal3:double}")]
    public IActionResult Promedio(double cal1, double cal2, double cal3)
    {
        double promedio = (cal1 + cal2 + cal3) / 3;
        return Ok($"El promedio es: {promedio:F2}");
    }

    // Ejercicio 5: Cuadrado de un número
    [HttpGet("Cuadrado/{num:double}")]
    public IActionResult Cuadrado(double num)
    {
        return Ok($"El cuadrado de {num} es: {num * num}");
    }

    // Ejercicio 6: Área del cuadrado
    [HttpGet("AreaCuadrado/{lado:double}")]
    public IActionResult AreaCuadrado(double lado)
    {
        return Ok($"El área del cuadrado es: {lado * lado}");
    }

    // Ejercicio 7: Perímetro del cuadrado
    [HttpGet("PerimetroCuadrado/{lado:double}")]
    public IActionResult PerimetroCuadrado(double lado)
    {
        return Ok($"El perímetro del cuadrado es: {lado * 4}");
    }

    // Ejercicio 8: Área del círculo
    [HttpGet("AreaCirculo/{radio:double}")]
    public IActionResult AreaCirculo(double radio)
    {
        double area = Math.PI * Math.Pow(radio, 2);
        return Ok($"El área del círculo es: {area:F2}");
    }

    // Ejercicio 9: Perímetro del círculo
    [HttpGet("PerimetroCirculo/{radio:double}")]
    public IActionResult PerimetroCirculo(double radio)
    {
        double perimetro = 2 * Math.PI * radio;
        return Ok($"El perímetro del círculo es: {perimetro:F2}");
    }

    // Ejercicio 10: Área del rectángulo
    [HttpGet("AreaRectangulo/{baseR:double}/{altura:double}")]
    public IActionResult AreaRectangulo(double baseR, double altura)
    {
        return Ok($"El área del rectángulo es: {baseR * altura}");
    }

    // Ejercicio 11: Área del triángulo
    [HttpGet("AreaTriangulo/{baseT:double}/{altura:double}")]
    public IActionResult AreaTriangulo(double baseT, double altura)
    {
        return Ok($"El área del triángulo es: {(baseT * altura) / 2}");
    }

    // Ejercicio 12: Porcentaje de una cantidad
    [HttpGet("Porcentaje/{cantidad:double}/{porcentaje:double}")]
    public IActionResult Porcentaje(double cantidad, double porcentaje)
    {
        double resultado = cantidad * porcentaje / 100;
        return Ok($"El {porcentaje}% de {cantidad} es: {resultado:F2}");
    }

    // Ejercicio 13: Dólares a pesos
    [HttpGet("DolaresAPesos/{dolares:double}")]
    public IActionResult DolaresAPesos(double dolares)
    {
        return Ok($"{dolares} dólares son: {dolares * PesosPorDolar:F2} pesos");
    }

    // Ejercicio 14: Dólares a euros
    [HttpGet("DolaresAEuros/{dolares:double}")]
    public IActionResult DolaresAEuros(double dolares)
    {
        double euros = dolares * PesosPorDolar / PesosPorEuro;
        return Ok($"{dolares} dólares son: {euros:F2} euros");
    }

    // Ejercicio 15: Pesos a dólares
    [HttpGet("PesosADolares/{pesos:double}")]
    public IActionResult PesosADolares(double pesos)
    {
        return Ok($"{pesos} pesos son: {pesos / PesosPorDolar:F2} dólares");
    }

    // Ejercicio 16: Pesos a euros
    [HttpGet("PesosAEuros/{pesos:double}")]
    public IActionResult PesosAEuros(double pesos)
    {
        return Ok($"{pesos} pesos son: {pesos / PesosPorEuro:F2} euros");
    }

    // Ejercicio 17: Euros a pesos
    [HttpGet("EurosAPesos/{euros:double}")]
    public IActionResult EurosAPesos(double euros)
    {
        return Ok($"{euros} euros son: {euros * PesosPorEuro:F2} pesos");
    }

    // Ejercicio 18: Euros a dólares
    [HttpGet("EurosADolares/{euros:double}")]
    public IActionResult EurosADolares(double euros)
    {
        double dolares = euros * PesosPorEuro / PesosPorDolar;
        return Ok($"{euros} euros son: {dolares:F2} dólares");
    }
}