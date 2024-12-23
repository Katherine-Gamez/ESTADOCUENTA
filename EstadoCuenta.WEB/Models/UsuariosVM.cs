using System;
namespace EstadoCuenta.WEB.Models
{
    public class UsuarioVM
    {

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}