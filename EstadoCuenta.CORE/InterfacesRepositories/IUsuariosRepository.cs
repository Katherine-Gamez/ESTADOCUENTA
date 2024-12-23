using EstadoCuenta.CORE.DTOs;
using EstadoCuenta.INFRASTRUCTURE.Data;

namespace EstadoCuenta.CORE.InterfacesRepositories
{
    public interface IUsuariosRepository
    {
        Task<List<UsuariosDto>> ObtenerUsuariosAsync();
    }
}

