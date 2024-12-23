using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.APPLICATION.Queries
{
	public class ObtenerEstadoCuentaQuery : IRequest<BaseResponse<EstadoCuentaDto>>
    {
        public int Id { get; set; }

        public ObtenerEstadoCuentaQuery(int id)
        {
            Id = id;
        }
    }
}

