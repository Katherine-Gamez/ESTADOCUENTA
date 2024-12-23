using EstadoCuenta.INFRASTRUCTURE.Configurations;
using Dapper;
using EstadoCuenta.INFRASTRUCTURE.Data;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.CORE.DTOs;

namespace EstadoCuenta.INFRASTRUCTURE.Repositories
{
	public class UsuariosRepository : IUsuariosRepository
    {
        private readonly DapperContext _applicationContext;

        public UsuariosRepository(DapperContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task<List<UsuariosDto>> ObtenerUsuariosAsync()
        {
            using var connection = _applicationContext.CreateConnection();
            var query = "SELECT USUARIO_ID AS UsuarioId, NOMBRE, APELLIDO, EMAIL FROM USUARIOS;";

            var users = await connection.QueryAsync<UsuariosDto>(query);

            return users.ToList();
        }
    }
}

