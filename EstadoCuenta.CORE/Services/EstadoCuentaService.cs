using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Services
{
    public class EstadoCuentaService : IEstadoCuentaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoCuentaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BaseResponse<EstadoCuentaDto>> ObtenerEstadoCuenta(int id)
        {
            var response = new BaseResponse<EstadoCuentaDto>();

            try
            {
                var cuenta = await _unitOfWork.Cuentas.ObtenerEstadoCuentaAsync(id);

                if (cuenta != null)
                {
                    var transacciones = cuenta.Transacciones?.Select(t => new TransaccionDto
                    {
                        TransaccionId = t.TransaccionId,
                        Tipo = t.Tipo,
                        Monto = t.Monto,
                        Descripcion = t.Descripcion,
                        Fecha = t.Fecha
                    }).ToList() ?? new List<TransaccionDto>(); 

                    response.Data = new EstadoCuentaDto
                    {
                        Titular = cuenta.Titular,
                        Tarjeta = cuenta.Tarjeta,
                        TotalSaldo = cuenta.TotalSaldo,
                        CreditoLimite = cuenta.CreditoLimite,
                        DisponibleSaldo = cuenta.DisponibleSaldo,
                        BonificacionInteres = cuenta.BonificacionInteres,
                        MinimoCuota = cuenta.MinimoCuota,
                        TotalAPagar = cuenta.TotalAPagar,
                        ContadoConIntereses = cuenta.ContadoConIntereses,
                        Transacciones = transacciones
                    };

                    response.succcess = true;
                    response.Message = "Estado de cuenta obtenido correctamente.";
                }
                else
                {
                    response.succcess = false;
                    response.Message = "No se encontraron cuentas.";
                }
            }
            catch (Exception ex)
            {
                response.succcess = false;
                response.Message = $"Error al obtener estado de cuenta: {ex.Message}";
            }

            return response;
        }
    }
}