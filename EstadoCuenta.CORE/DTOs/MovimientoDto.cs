using System;
using System.Globalization;

namespace EstadoCuenta.CORE.DTOs
{
	public class MovimientoDto
	{
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}

