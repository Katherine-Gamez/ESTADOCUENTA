using System;
using AutoMapper;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Data;
using MediatR;

namespace EstadoCuenta.APPLICATION.Commands
{
	public class CrearMovimientoHandler : IRequestHandler<CrearMovimientoCommand, BaseResponse<bool>>
    {
        private readonly IMovimientosServices _movimientosServices;
        private readonly IMapper _mapper;

        public CrearMovimientoHandler(IMovimientosServices movimientosServices, IMapper mapper)
        {
            _movimientosServices = movimientosServices ?? throw new ArgumentNullException(nameof(movimientosServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(CrearMovimientoCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var movimientoDto = _mapper.Map<MovimientoDto>(command.movimientoDto);
                response.Data = await _movimientosServices.AgregarMovimiento(movimientoDto);

                if (response.Data)
                {
                    response.succcess = true;
                    response.Message = "Movimiento creado exitosamente.";
                }
                else
                {
                    response.succcess = false;
                    response.Message = "No se pudo crear el movimiento.";
                }
            }
            catch (Exception ex)
            {
                response.succcess = false;
                response.Message = $"Error: {ex.Message}";
            }

            return response;
        }
    }
}