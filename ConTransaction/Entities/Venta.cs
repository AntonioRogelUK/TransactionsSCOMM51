using System;
using System.Collections.Generic;

namespace ConTransaction.Entities
{
    internal class Venta
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get { return CalcularTotal(); } }

        public List<VentaDetalle> Conceptos { get; set; } = new List<VentaDetalle>();


        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var concepto in Conceptos)
            {
                total += concepto.Importe;

            }
            return total;
        }
    }
}
