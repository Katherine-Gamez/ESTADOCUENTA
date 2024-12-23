using AutoMapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.APPLICATION.Queries
{
    public class ObtenerTransaccionesHandler : IRequestHandler<ObtenerTransaccionesQuery, BaseResponse<IEnumerable<TransaccionesDto>>>
    {
        private readonly ITransaccionesServices _services;
        private readonly IMapper _mapper;

        public ObtenerTransaccionesHandler(ITransaccionesServices services, IMapper mapper)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<IEnumerable<TransaccionesDto>>> Handle(ObtenerTransaccionesQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<TransaccionesDto>>();

            try
            {
                var result = await _services.ObtenerTransacciones(request.Id);
                if (result != null && result.Data != null)
                {
                    response.Data = _mapper.Map<IEnumerable<TransaccionesDto>>(result.Data);
                    response.succcess = true;
                    response.Message = "Consulta exitosa.";
                }
                else
                {
                    response.succcess = true;
                    response.Message = "No se encontraron transacciones para el usuario proporcionado.";
                }
            }
            catch (Exception ex)
            {
                response.succcess = false;
                response.Message = $"Error al obtener transacciones: {ex.Message}";
            }

            return response;
        }
    }
}
