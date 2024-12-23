using System;
using Dapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Configurations;

namespace EstadoCuenta.INFRASTRUCTURE.Repositories
{
	public class TransaccionesRepository: ITransaccionesRepository
	{
        private readonly DapperContext _applicationContext;

        public TransaccionesRepository(DapperContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task<List<TransaccionesDto>> ObtenerTransacciones(int tarjetaId)
        {
        
            using var connection = _applicationContext.CreateConnection();
            var query = @"
                SELECT * 
                FROM VW_HISTORIALTRANSACCIONES 
                WHERE TARJETA_ID = @TarjetaId 
                ORDER BY FECHA DESC;";
            var parametros = new { TarjetaId = tarjetaId};

            var transacciones = await connection.QueryAsync<TransaccionesDto>(query, parametros);
            return transacciones.ToList();
        }
    }
}

