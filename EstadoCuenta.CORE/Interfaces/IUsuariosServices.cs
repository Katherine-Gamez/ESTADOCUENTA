using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Interfaces
{
	public interface IUsuariosServices
	{

        Task<BaseResponse<IEnumerable<UsuariosDto>>> ObtenerUsuarios();

    }
}

