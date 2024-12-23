using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstadoCuenta.APPLICATION.Queries;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.INFRASTRUCTURE.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoTarjetaController : Controller
    {
        private readonly IMediator _mediator;

        public EstadoTarjetaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<UsuariosDto>>> ObtenerEstadoCuenta(int id, CancellationToken cancellationToken)
        {
            var query = new ObtenerEstadoCuentaQuery(id);  
            try
            {
                var response = await _mediator.Send(query, cancellationToken);

                if (response.succcess)
                {
                    return Ok(response);
                }

                return NotFound(new { Message = "Datos no encontrados." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

    }
}


