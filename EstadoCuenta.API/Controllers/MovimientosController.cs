using System;
using EstadoCuenta.APPLICATION.Commands;
using EstadoCuenta.APPLICATION.Queries;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : Controller
    {
        private readonly IMediator _mediator;

        public MovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult> AgregarMovimiento([FromBody] MovimientoDto movimientoDto, CancellationToken cancellationToken)
        {
            try
            {

                var resultado = await _mediator.Send(new CrearMovimientoCommand(movimientoDto));

                if (resultado.succcess == true)
                {
                    return Ok(new { Message = "Movimiento agregado exitosamente." });
                }
                else
                {
                    return BadRequest(new { Message = "Hubo un problema al agregar el movimiento." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}

