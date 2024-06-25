using ConTransaction.Commands;
using ConTransaction.Database;
using ConTransaction.Entities;
using System;
using System.Data.SqlClient;

namespace ConTransaction.Services
{
    internal class VentaServices
    {
        public int GuardarVenta(Venta venta)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();

                    try
                    {
                        FoliosCommands foliosCommands = new FoliosCommands();
                        venta.Folio = foliosCommands.ObtenerSiguienteFolio(con, tran);

                        VentaCommand command = new VentaCommand();
                        venta.Id = command.GuardarVenta(con, tran, venta);

                        foliosCommands.ActualizarFolio(con, tran);

                        int renglon = 1;
                        foreach (VentaDetalle concepto in venta.Conceptos)
                        {
                            concepto.VentaId = venta.Id;
                            concepto.Renglon = renglon;

                            VentaDetalleCommands conceptoCommand = new VentaDetalleCommands();
                            conceptoCommand.GuardarVentaDetalle(con, tran, concepto);

                            renglon++;
                        }

                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
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
