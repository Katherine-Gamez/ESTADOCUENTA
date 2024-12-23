using System;
namespace EstadoCuenta.CORE.DTOs
{
	public class TransaccionesDto
	{
        public string Titular { get; set; }
        public string Tarjeta { get; set; }
        public string Tipo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

    }
}

