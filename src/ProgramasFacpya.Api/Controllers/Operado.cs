using Microsoft.AspNetCore.Mvc;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Selectivas : ControllerBase
{
    // -------------------------------------------------------------
    // Ejercicio 1
    // Determinar si un numero es mayor a 0, menor a 0 o igual a 0.
    // GET api/Selectivas/SignoNumero/-5
    // -------------------------------------------------------------
    [HttpGet("SignoNumero/{numero:double}")]
    public IActionResult SignoNumero(double numero)
    {
        if (numero > 0)
        {
            return Ok($"El numero {numero} es MAYOR a 0.");
        }
        else if (numero < 0)
        {
            return Ok($"El numero {numero} es MENOR a 0.");
        }
        else
        {
            return Ok($"El numero {numero} es IGUAL a 0.");
        }
    }

    // -------------------------------------------------------------
    // Ejercicio 2
    // Promedio de 5 materias. Si esta entre 60 y 100 -> APROBO,
    // de lo contrario NO APROBO.
    // GET api/Selectivas/Promedio5/70/80/65/90/55
    // -------------------------------------------------------------
    [HttpGet("Promedio5/{m1:double}/{m2:double}/{m3:double}/{m4:double}/{m5:double}")]
    public IActionResult Promedio5(double m1, double m2, double m3, double m4, double m5)
    {
        double promedio = (m1 + m2 + m3 + m4 + m5) / 5;

        if (promedio >= 60 && promedio <= 100)
        {
            return Ok($"Promedio: {promedio}. El estudiante APROBO el semestre.");
        }
        else
        {
            return Ok($"Promedio: {promedio}. El estudiante NO APROBO el semestre.");
        }
    }

    // -------------------------------------------------------------
    // Ejercicio 3
    // Leer tres valores (Num1, Num2, Num3), validar que sean
    // distintos e imprimir cual es el mayor.
    // GET api/Selectivas/Mayor/4/9/2
    // -------------------------------------------------------------
    [HttpGet("Mayor/{Num1:int}/{Num2:int}/{Num3:int}")]
    public IActionResult Mayor(int Num1, int Num2, int Num3)
    {
        // Validacion: los tres valores deben ser distintos entre si
        if (Num1 == Num2 || Num1 == Num3 || Num2 == Num3)
        {
            return BadRequest("Los tres valores deben ser distintos entre si.");
        }

        int mayor;

        if (Num1 > Num2 && Num1 > Num3)
        {
            mayor = Num1;
        }
        else if (Num2 > Num3)
        {
            mayor = Num2;
        }
        else
        {
            mayor = Num3;
        }

        return Ok($"El mayor de los tres valores es: {mayor}");
    }

    // -------------------------------------------------------------
    // Ejercicio 4
    // Ingresar 3 numeros enteros y mostrar el menor de los 3.
    // GET api/Selectivas/Menor/4/9/2
    // -------------------------------------------------------------
    [HttpGet("Menor/{num1:int}/{num2:int}/{num3:int}")]
    public IActionResult Menor(int num1, int num2, int num3)
    {
        int menor;

        if (num1 <= num2 && num1 <= num3)
        {
            menor = num1;
        }
        else if (num2 <= num3)
        {
            menor = num2;
        }
        else
        {
            menor = num3;
        }

        return Ok($"El menor de los tres numeros es: {menor}");
    }

    // -------------------------------------------------------------
    // Ejercicio 5
    // Indicar si un valor numerico es par o no es par.
    // GET api/Selectivas/ParOImpar/7
    // -------------------------------------------------------------
    [HttpGet("ParOImpar/{numero:int}")]
    public IActionResult ParOImpar(int numero)
    {
        if (numero % 2 == 0)
        {
            return Ok($"El numero {numero} es PAR.");
        }
        else
        {
            return Ok($"El numero {numero} NO es par (es impar).");
        }
    }

    // -------------------------------------------------------------
    // Ejercicio 6
    // Determinar si una letra ingresada es una vocal o no.
    // GET api/Selectivas/EsVocal/A
    // -------------------------------------------------------------
    [HttpGet("EsVocal/{letra}")]
    public IActionResult EsVocal(string letra)
    {
        if (string.IsNullOrEmpty(letra) || letra.Length != 1)
        {
            return BadRequest("Debes ingresar un solo caracter.");
        }

        char caracter = char.ToLower(letra[0]);

        if (!char.IsLetter(caracter))
        {
            return BadRequest("El caracter ingresado no es una letra.");
        }

        if (caracter == 'a' || caracter == 'e' || caracter == 'i' ||
            caracter == 'o' || caracter == 'u')
        {
            return Ok($"La letra '{letra}' SI es una vocal.");
        }
        else
        {
            return Ok($"La letra '{letra}' NO es una vocal (es consonante).");
        }
    }
}