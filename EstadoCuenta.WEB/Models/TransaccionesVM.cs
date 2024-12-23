using System;
using System.Globalization;

namespace EstadoCuenta.WEB.Models
{
	public class TransaccionesVM
	{
        public string Titular { get; set; }
        public string Tarjeta { get; set; }
        public string Tipo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }


        public string MontoFormatted => Monto.ToString("C", new CultureInfo("en-US"));
    }
}

