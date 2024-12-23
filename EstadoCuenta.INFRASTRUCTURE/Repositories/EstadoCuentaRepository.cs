using System;
using Dapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EstadoCuenta.INFRASTRUCTURE.Repositories
{
    public class EstadoCuentaRepository : IEstadoCuentaRepository
    {
        private readonly DapperContext _applicationContext;

        public EstadoCuentaRepository(DapperContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task<EstadoCuentaDto> ObtenerEstadoCuentaAsync(int tarjetaId)
        {
            var estadoCuenta = new EstadoCuentaDto();

            using var connection = _applicationContext.CreateConnection();
            var query = "EXEC SP_OBTENER_ESTADOCUENTA @TARJETA_ID = @TarjetaId, @PORCENTAJE_INTERES = @PorcentajeInteres, @PORCENTAJE_SALDO_MINIMO = @PorcentajeSaldoMinimo";
            var parametros = new { TarjetaId = tarjetaId, PorcentajeInteres = 25.00, PorcentajeSaldoMinimo = 5.00 };

            using (var multi = await connection.QueryMultipleAsync(query, parametros))
            {
                var cuenta = await multi.ReadFirstOrDefaultAsync<EstadoCuentaDto>();
                if (cuenta != null)
                {
                    estadoCuenta.Titular = cuenta.Titular;
                    estadoCuenta.Tarjeta = cuenta.Tarjeta;
                    estadoCuenta.TotalSaldo = cuenta.TotalSaldo;
                    estadoCuenta.CreditoLimite = cuenta.CreditoLimite;
                    estadoCuenta.DisponibleSaldo = cuenta.DisponibleSaldo;
                    estadoCuenta.BonificacionInteres = cuenta.BonificacionInteres;
                    estadoCuenta.MinimoCuota = cuenta.MinimoCuota;
                    estadoCuenta.TotalAPagar = cuenta.TotalAPagar;
                    estadoCuenta.ContadoConIntereses = cuenta.ContadoConIntereses;
                }
                var transacciones = await multi.ReadAsync<TransaccionDto>();
                estadoCuenta.Transacciones = transacciones.ToList();
            }

            return estadoCuenta;
        }
    }
}