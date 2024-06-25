using SinTransaction.Commands;
using SinTransaction.Entities;
using System;

namespace SinTransaction.Services
{
    internal class VentaServices
    {
        public int GuardarVenta(Venta venta)
        {
            try
            {

                FoliosCommands foliosCommands = new FoliosCommands();
                venta.Folio = foliosCommands.ObtenerSiguienteFolio();

                VentaCommand command = new VentaCommand();
                venta.Id = command.GuardarVenta(venta);

                foliosCommands.ActualizarFolio();

                int renglon = 1;

                foreach (VentaDetalle concepto in venta.Conceptos)
                {
                    concepto.VentaId = venta.Id;
                    concepto.Renglon = renglon;

                    VentaDetalleCommands conceptoCommand = new VentaDetalleCommands();
                    conceptoCommand.GuardarVentaDetalle(concepto);

                    renglon++;


                }

                return venta.Folio;


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
