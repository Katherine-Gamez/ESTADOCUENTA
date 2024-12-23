using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Configurations;

namespace EstadoCuenta.INFRASTRUCTURE.Repositories
{
    public class MovimientosRepository : IMovimientosRepository
    {
        private readonly DapperContext _applicationContext;

        public MovimientosRepository(DapperContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task<bool> AgregarMovimientos(MovimientoDto movimientoDto)
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "SP_REGISTRARTRANSACCION";
            var parameters = new
            {
                TARJETA_ID = movimientoDto.Id,
                TIPO = movimientoDto.Tipo,
                MONTO = movimientoDto.Monto,
                DESCRIPCION = movimientoDto.Descripcion,
                FECHA= movimientoDto.Fecha
            };

            var result = await connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
