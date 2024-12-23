using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.APPLICATION.Queries
{
	public class ObtenerTransaccionesQuery : IRequest<BaseResponse<IEnumerable<TransaccionesDto>>>
    {
        public int Id { get; set; }

        public ObtenerTransaccionesQuery(int id)
        {
            Id = id;
        }
    }
}

