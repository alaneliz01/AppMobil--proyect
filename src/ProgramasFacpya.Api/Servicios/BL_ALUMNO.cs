using ProgramasFacpya.Api.Models;
namespace ProgramasFacpya.Api.Servicios;

public class BL_ALUMNO
{
    public static List <string> Validaciones(string Nombre, string APaterno, string AMaterno)
    {
        List<string> lsErrores = new List<string>();
        if (Nombre.Replace(" ","").Length < 3)
            lsErrores.Add("El nombre debe tener al menos 3 caracteres.");

        if (ValidaTexto(Nombre))
        {
        lsErrores.Add("El nombre no es válido.");
        }
        if (ValidaTexto(APaterno))
        {
         lsErrores.Add("El apellido paterno no es válido.");
         // break;
        }
        if (ValidaTexto(AMaterno))
        {
            lsErrores.Add("El apellido materno no es válido.");
            // break;
        }
        return lsErrores;
    

    }
    public static List<string> Validaciones2(ALUMNO2 Alumno)
    {
        List<string> lstErrores = new List<string>();
 
        if (Alumno.Nombre.Replace(" ", "").Length < 3)
            lstErrores.Add("El nombre debe tener al menos 3 caracteres.");
 
        if (ValidaTexto(Alumno.Nombre))
            lstErrores.Add("El nombre solo debe contener letras.");
 
        if (Alumno.APaterno.Replace(" ", "").Length < 3)
            lstErrores.Add("El apellido paterno debe tener al menos 3 caracteres.");
 
        if (ValidaTexto(Alumno.APaterno))
            lstErrores.Add("El apellido paterno solo debe contener letras.");
 
        if (Alumno.AMaterno.Replace(" ", "").Length < 3)
            lstErrores.Add("El apellido materno debe tener al menos 3 caracteres.");
 
        if (ValidaTexto(Alumno.AMaterno))
            lstErrores.Add("El apellido materno solo debe contener letras.");
 
        return lstErrores;
    }

    private static bool ValidaTexto(string P_Texto)
    {
        bool IsActivo = false;
        List<string> lsErrores = new List<string>();
        foreach(char letra in P_Texto)
        {
            
            if (!char.IsLetter(letra) && letra != ' ')
            {
                IsActivo = true;
                break;
            }
        }
        return IsActivo;
    }
}
