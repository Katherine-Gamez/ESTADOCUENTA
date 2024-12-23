using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Interfaces
{
	public interface ITransaccionesServices
	{
        Task<BaseResponse<IEnumerable<TransaccionesDto>>> ObtenerTransacciones(int id);
    }
}

