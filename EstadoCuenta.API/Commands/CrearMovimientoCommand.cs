using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.APPLICATION.Commands
{
	public class CrearMovimientoCommand : IRequest<BaseResponse<bool>>
    {
        public MovimientoDto movimientoDto { get; set; }

        public CrearMovimientoCommand(MovimientoDto movimiento)
        {
            movimientoDto = movimiento;
        }
    }
}

