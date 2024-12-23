using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Interfaces
{
	public interface IEstadoCuentaService
	{
        Task<BaseResponse<EstadoCuentaDto>> ObtenerEstadoCuenta(int id);
    }
}

