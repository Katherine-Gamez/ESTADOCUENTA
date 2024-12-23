using System;
using EstadoCuenta.CORE.Interfaces;

namespace EstadoCuenta.CORE.InterfacesRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuariosRepository Users { get; }
        IEstadoCuentaRepository Cuentas { get; }
        IMovimientosRepository Movimientos { get; }
        ITransaccionesRepository Transacciones { get; }
    }
}

