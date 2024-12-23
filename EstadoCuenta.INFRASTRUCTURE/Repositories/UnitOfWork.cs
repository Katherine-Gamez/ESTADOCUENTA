using System;
using System.Data;
using EstadoCuenta.CORE.InterfacesRepositories;
using EstadoCuenta.INFRASTRUCTURE.Configurations;

namespace EstadoCuenta.INFRASTRUCTURE.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DapperContext _context;
        public IUsuariosRepository Users { get; }
        public IEstadoCuentaRepository Cuentas { get; }
        public IMovimientosRepository Movimientos { get; }
        public ITransaccionesRepository Transacciones { get; }

        public UnitOfWork(IUsuariosRepository users, DapperContext context, IEstadoCuentaRepository cuentas, IMovimientosRepository movRepository, ITransaccionesRepository repository)
        {
            Users = users ?? throw new ArgumentNullException(nameof(users));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Cuentas = cuentas ?? throw new ArgumentNullException(nameof(cuentas));
            Movimientos = movRepository ?? throw new ArgumentNullException(nameof(movRepository));
            Transacciones = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IDbTransaction BeginTransaction()
        {
            var connection = _context.CreateConnection();
            return connection.BeginTransaction();
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}