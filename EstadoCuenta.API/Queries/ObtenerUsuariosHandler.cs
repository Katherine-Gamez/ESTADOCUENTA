using AutoMapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.INFRASTRUCTURE.Queries
{
    public class ObtenerUsuariosHandler : IRequestHandler<ObtenerUsuariosQuery, BaseResponse<IEnumerable<UsuariosDto>>>
    {
        private readonly IUsuariosServices _services;
        private readonly IMapper _mapper;

        public ObtenerUsuariosHandler(IUsuariosServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<IEnumerable<UsuariosDto>>> Handle(ObtenerUsuariosQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<UsuariosDto>>();

            try
            {
                var customers = await _services.ObtenerUsuarios();
                if (customers is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<UsuariosDto>>(customers.Data);
                    response.succcess = true;
                    response.Message = "Query succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
