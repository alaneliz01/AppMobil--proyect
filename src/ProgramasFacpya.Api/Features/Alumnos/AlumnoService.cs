using Dapper;
using FluentValidation;
using ProgramasFacpya.Api.Common;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Entidad;
using ProgramasFacpya.Api.Data;

namespace ProgramasFacpya.Api.Features.Alumnos;

public class AlumnoService(DbContext db, IValidator<AlumnoDTO> validator)
{
    private readonly DbContext _db = db;
    private readonly IValidator<AlumnoDTO> _validator = validator; // Sin '}' extra al final

    public async Task<ApiResponse<IEnumerable<Alumno>>> ObtenerTodos()
    {
        using var connection = _db.CreateConnection();
        var sql = @"SELECT a.IdAlumno,
                           a.Nombre,
                           a.APaterno,
                           a.AMaterno,
                           a.IdCarrera,
                           a.FecRegistro,
                           c.Descripcion AS Carrera
                    FROM ALUMNO a
                         INNER JOIN CARRERA c ON a.IdCarrera = c.IdCarrera
                    ORDER BY a.APaterno, a.AMaterno, a.Nombre";

        var alumnos = await connection.QueryAsync<Alumno>(sql);
        return ApiResponse<IEnumerable<Alumno>>.Ok(alumnos);
    }
}