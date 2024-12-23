using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Services
{
    public class TransaccionesServices : ITransaccionesServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransaccionesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BaseResponse<IEnumerable<TransaccionesDto>>> ObtenerTransacciones(int id)
        {
            var response = new BaseResponse<IEnumerable<TransaccionesDto>>();

            try
            { 
                var transacciones = await _unitOfWork.Transacciones.ObtenerTransacciones(id);

                if (transacciones != null && transacciones.Any())
                {
                    response.Data = transacciones; 
                    response.succcess = true;
                    response.Message = "Transacciones obtenidas correctamente.";
                }
                else
                {
                    response.succcess = true;
                    response.Message = "No se encontraron transacciones.";
                }
            }
            catch (Exception ex)
            {
                response.succcess = false;
                response.Message = $"Error al obtener las transacciones: {ex.Message}";
            }

            return response;
        }
    }
}
