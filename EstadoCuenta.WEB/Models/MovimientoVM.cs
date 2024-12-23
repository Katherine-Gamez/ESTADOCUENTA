using System;
namespace EstadoCuenta.WEB.Models
{
	public class MovimientoVM
	{
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string Monto { get; set; }
        public DateTime Fecha { get; set; }

    }
}

