using System;
using EstadoCuenta.CORE.DTOs;

namespace EstadoCuenta.CORE.InterfacesRepositories
{
	public interface ITransaccionesRepository
	{
        Task<List<TransaccionesDto>> ObtenerTransacciones(int tarjetaId);
    }
}

