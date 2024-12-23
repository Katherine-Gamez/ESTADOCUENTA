using System;
using System.Threading.Tasks;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Services
{
    public class MovimientosServices : IMovimientosServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovimientosServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AgregarMovimiento(MovimientoDto movimientoDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(movimientoDto.Descripcion))
                {
                    movimientoDto.Descripcion = null;
                }

                var resultado = await _unitOfWork.Movimientos.AgregarMovimientos(movimientoDto);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el movimiento: {ex.Message}", ex);
       
            }
        }
    }
}
