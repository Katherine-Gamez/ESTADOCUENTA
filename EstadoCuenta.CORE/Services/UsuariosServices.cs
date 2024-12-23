using System;
using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.Services
{
    public class UsuariosService: IUsuariosServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuariosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BaseResponse<IEnumerable<UsuariosDto>>> ObtenerUsuarios()
        {
            var response = new BaseResponse<IEnumerable<UsuariosDto>>();

            try
            {
                var usuarios = await _unitOfWork.Users.ObtenerUsuariosAsync();

                if (usuarios != null)
                {
                    response.Data = usuarios.Select(u => new UsuariosDto
                    {
                        UsuarioId = u.UsuarioId,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Email = u.Email
                    }).ToList();
                    response.succcess = true;
                    response.Message = "Usuarios obtenidos correctamente.";
                }
                else
                {
                    response.succcess = false;
                    response.Message = "No se encontraron usuarios.";
                }
            }
            catch (Exception ex)
            {
                response.succcess = false;
                response.Message = $"Error al obtener usuarios: {ex.Message}";
            }

            return response;
        }
    }

}

