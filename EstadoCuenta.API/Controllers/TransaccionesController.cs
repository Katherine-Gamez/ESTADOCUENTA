using EstadoCuenta.APPLICATION.Queries;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.APPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : Controller
    {

        private readonly IMediator _mediator;

        public TransaccionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<IEnumerable<TransaccionesDto>>>> ObtenerTransacciones(int id, CancellationToken cancellationToken)
        {
            var query = new ObtenerTransaccionesQuery(id);

            try
            {
                var response = await _mediator.Send(query, cancellationToken);

                if (response.succcess) 
                {
                    return Ok(response);
                }

                return NotFound(new { Message = response.Message ?? "Datos no encontrados." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Error interno del servidor: {ex.Message}" });
            }
        }
    }
}