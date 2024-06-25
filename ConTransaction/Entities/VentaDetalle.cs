namespace ConTransaction.Entities
{
    internal class VentaDetalle
    {
        public int Id { get; set; }
        public int Renglon { get; set; }
        public int VentaId { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get { return CalcularImporte(); } }

        private decimal CalcularImporte()
        {
            return Cantidad * PrecioUnitario;

        }
    }
}
