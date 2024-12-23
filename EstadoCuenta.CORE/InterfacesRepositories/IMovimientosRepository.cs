using System;
using EstadoCuenta.CORE.DTOs;

namespace EstadoCuenta.CORE.InterfacesRepositories
{
	public interface IMovimientosRepository
	{
        Task<bool> AgregarMovimientos(MovimientoDto movimientoDto);
    }
}

