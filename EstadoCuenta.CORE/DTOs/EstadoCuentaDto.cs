using System;
namespace EstadoCuenta.CORE.DTOs
{
	public class EstadoCuentaDto
	{
        public string Titular { get; set; }
        public string Tarjeta { get; set; }
        public decimal TotalSaldo { get; set; }
        public decimal CreditoLimite { get; set; }
        public decimal DisponibleSaldo { get; set; }
        public decimal BonificacionInteres { get; set; }
        public decimal MinimoCuota { get; set; }
        public decimal TotalAPagar { get; set; }
        public decimal ContadoConIntereses { get; set; }

        public List<TransaccionDto> Transacciones { get; set; }
    }

    public class TransaccionDto
    {
        public int TransaccionId { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}

