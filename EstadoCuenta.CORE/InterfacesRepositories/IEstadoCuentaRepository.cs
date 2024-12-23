using System;
using EstadoCuenta.CORE.DTOs;

namespace EstadoCuenta.CORE.InterfacesRepositories
{
	public interface IEstadoCuentaRepository
	{
        Task<EstadoCuentaDto> ObtenerEstadoCuentaAsync(int tarjetaId);
    }
}

