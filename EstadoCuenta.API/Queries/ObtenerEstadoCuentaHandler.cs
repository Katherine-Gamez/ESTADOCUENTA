using System;
using AutoMapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.INFRASTRUCTURE.Queries;
using MediatR;

namespace EstadoCuenta.APPLICATION.Queries
{
    public class ObtenerEstadoCuentaHandler : IRequestHandler<ObtenerEstadoCuentaQuery, BaseResponse<EstadoCuentaDto>>
    {
        private readonly IEstadoCuentaService _services;
        private readonly IMapper _mapper;

        public ObtenerEstadoCuentaHandler(IEstadoCuentaService services, IMapper mapper)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<EstadoCuentaDto>> Handle(ObtenerEstadoCuentaQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<EstadoCuentaDto>();

            try
            {
                var result = await _services.ObtenerEstadoCuenta(request.Id);
                if (result != null && result.Data != null)
                {
                    response.Data = _mapper.Map<EstadoCuentaDto>(result.Data);
                    response.succcess = true;
                    response.Message = "Query succeed!";
                }
                else
                {
                    response.succcess = false;
                    response.Message = "No se encontraron datos para el estado de cuenta.";
                }
            }
            catch (Exception ex)
            {
                response.succcess = false;
                response.Message = $"Error al obtener estado de cuenta: {ex.Message}";
            }

            return response;
        }
    }
}