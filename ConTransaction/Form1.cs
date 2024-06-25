using ConTransaction.Entities;
using ConTransaction.Services;
using System;
using System.Windows.Forms;

namespace ConTransaction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Venta venta = new Venta();
                venta.Cliente = "Edgar";

                VentaDetalle soda = new VentaDetalle();
                soda.Cantidad = 2;
                soda.Descripcion = "Coca cola 1lt";
                soda.PrecioUnitario = 30;
                venta.Conceptos.Add(soda);

                VentaDetalle sabritas = new VentaDetalle();
                sabritas.Cantidad = 2;
                sabritas.Descripcion = "Doritos";
                sabritas.PrecioUnitario = 25;
                venta.Conceptos.Add(sabritas);

                VentaServices ventaServices = new VentaServices();
                int folio = ventaServices.GuardarVenta(venta);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
