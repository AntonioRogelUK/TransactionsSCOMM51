using SinTransaction.Database;
using SinTransaction.Entities;
using System;
using System.Data.SqlClient;

namespace SinTransaction.Commands
{
    internal class VentaDetalleCommands
    {
        public void GuardarVentaDetalle(VentaDetalle concepto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    string query = @" insert into VentasDetalle
                      (Renglon,VentaId,Cantidad,Descripcion,PrecioUnitario,Importe)
                      values 
                      (@Renglon,@VentaId,@Cantidad,@Descripcion,@PrecioUnitario,@Importe)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Renglon", concepto.Renglon);
                        cmd.Parameters.AddWithValue("@VentaId", concepto.VentaId);
                        cmd.Parameters.AddWithValue("@Cantidad", concepto.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", concepto.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@Descripcion", concepto.Descripcion);
                        cmd.Parameters.AddWithValue("@Importe", concepto.Importe);

                        con.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas == 0)
                        {
                            throw new Exception($"No se pudo insertar concepto de venta renglon({concepto.Renglon})");
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
