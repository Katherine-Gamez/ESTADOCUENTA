using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.INFRASTRUCTURE.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstadoCuenta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<UsuariosDto>>>> ObtenerUsuarios(CancellationToken cancellationToken)
        {
  
            var query = new ObtenerUsuariosQuery();

            try
            {
                var response = await _mediator.Send(query, cancellationToken);
                if (response.succcess)
                {
                    return Ok(response); 
                }

                return NotFound(new { Message = "Usuario no encontrado." }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}