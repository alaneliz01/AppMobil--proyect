using Dapper;
using FluentValidation;
using ProgramasFacpya.Api.Common;
using ProgramasFacpya.Api.Data;
using ProgramasFacpya.Api.Features.Carreras.Dominio.Dto;
using ProgramasFacpya.Api.Features.Carreras.Dominio.Entidad;

namespace ProgramasFacpya.Api.Features.Carreras;

public class CarreraService(DbContext db, IValidator<CarreraDTO> validator)
{
    private readonly DbContext _db = db;
    private readonly IValidator<CarreraDTO> _validator = validator;

    public async Task<ApiResponse<IEnumerable<Carrera>>> ObtenerTodos()
    {
        using var connection = _db.CreateConnection();
        var sql = @"SELECT IdCarrera, Descripcion
                    FROM CARRERA
                    ORDER BY IdCarrera";

        var carreras = await connection.QueryAsync<Carrera>(sql);
        return ApiResponse<IEnumerable<Carrera>>.Ok(carreras);
    }

    public async Task<ApiResponse<Carrera>> ObtenerPorId(int idCarrera)
    {
        using var connection = _db.CreateConnection();
        var sql = @"SELECT IdCarrera, Descripcion
                    FROM CARRERA
                    WHERE IdCarrera = @IdCarrera";

        var carrera = await connection.QueryFirstOrDefaultAsync<Carrera>(sql, new { IdCarrera = idCarrera });

        if (carrera == null)
            return ApiResponse<Carrera>.Error("Carrera no encontrada");

        return ApiResponse<Carrera>.Ok(carrera);
    }

    public async Task<ApiResponse<int>> Crear(CarreraDTO dto)
    {
        var validacion = await _validator.ValidateAsync(dto);
        if (!validacion.IsValid)
            return ApiResponse<int>.Error(validacion.Errors.First().ErrorMessage);

        using var connection = _db.CreateConnection();
        var sql = @"INSERT INTO CARRERA (Descripcion)
                    VALUES (@Descripcion);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

        var idCarrera = await connection.ExecuteScalarAsync<int>(sql, new { dto.Descripcion });
        return ApiResponse<int>.Ok(idCarrera, "Carrera registrada");
    }

    public async Task<ApiResponse<string>> Actualizar(int idCarrera, CarreraDTO dto)
    {
        var validacion = await _validator.ValidateAsync(dto);
        if (!validacion.IsValid)
            return ApiResponse<string>.Error(validacion.Errors.First().ErrorMessage);

        using var connection = _db.CreateConnection();
        var sql = @"UPDATE CARRERA SET Descripcion = @Descripcion
                    WHERE IdCarrera = @IdCarrera";

        var filas = await connection.ExecuteAsync(sql, new { IdCarrera = idCarrera, dto.Descripcion });
        if (filas == 0)
            return ApiResponse<string>.Error("Carrera no encontrada");

        return ApiResponse<string>.Ok("Carrera actualizada correctamente");
    }

    public async Task<ApiResponse<string>> Eliminar(int idCarrera)
    {
        using var connection = _db.CreateConnection();
        var sql = "DELETE FROM CARRERA WHERE IdCarrera = @IdCarrera";

        var filas = await connection.ExecuteAsync(sql, new { IdCarrera = idCarrera });
        if (filas == 0)
            return ApiResponse<string>.Error("Carrera no encontrada");

        return ApiResponse<string>.Ok("Carrera eliminada correctamente");
    }
}
