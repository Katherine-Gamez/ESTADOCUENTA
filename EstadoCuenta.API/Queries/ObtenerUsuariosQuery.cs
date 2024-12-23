using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.INFRASTRUCTURE.Queries
{
    public class ObtenerUsuariosQuery : IRequest<BaseResponse<IEnumerable<UsuariosDto>>>
    {
    }
}
