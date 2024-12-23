using System;
using System.Globalization;

namespace EstadoCuenta.WEB.Models
{
    public class EstadoCuentaVM
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

        public List<TransaccionVM> Transacciones { get; set; }

        public string TotalSaldoFormatted => TotalSaldo.ToString("C", new CultureInfo("en-US"));
        public string CreditoLimiteFormatted => CreditoLimite.ToString("C", new CultureInfo("en-US"));
        public string DisponibleSaldoFormatted => DisponibleSaldo.ToString("C", new CultureInfo("en-US"));
        public string BonificacionInteresFormatted => BonificacionInteres.ToString("C", new CultureInfo("en-US"));
        public string MinimoCuotaFormatted => MinimoCuota.ToString("C", new CultureInfo("en-US"));
        public string TotalAPagarFormatted => TotalAPagar.ToString("C", new CultureInfo("en-US"));
        public string ContadoConInteresesFormatted => ContadoConIntereses.ToString("C", new CultureInfo("en-US"));
    }

    public class TransaccionVM
    {
        public int TransaccionId { get; set; }
        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string MontoFormatted => Monto.ToString("C", new CultureInfo("en-US"));
    }
}