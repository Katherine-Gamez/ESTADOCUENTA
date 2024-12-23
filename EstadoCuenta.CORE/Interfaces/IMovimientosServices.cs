using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Interfaces
{
	public interface IMovimientosServices
	{
        Task<bool> AgregarMovimiento(MovimientoDto movimientoDto);
    }
}

