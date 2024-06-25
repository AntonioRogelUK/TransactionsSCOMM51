using ConTransaction.Entities;
using System;
using System.Data.SqlClient;

namespace ConTransaction.Commands
{
    internal class VentaDetalleCommands
    {
        public void GuardarVentaDetalle(SqlConnection con, SqlTransaction transaction, VentaDetalle concepto)
        {
            try
            {

                string query = @" insert into VentasDetalle
                      (Renglon,VentaId,Cantidad,Descripcion,PrecioUnitario,Importe)
                      values 
                      (@Renglon,@VentaId,@Cantidad,@Descripcion,@PrecioUnitario,@Importe)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@Renglon", concepto.Renglon);
                    cmd.Parameters.AddWithValue("@VentaId", concepto.VentaId);
                    cmd.Parameters.AddWithValue("@Cantidad", concepto.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", concepto.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Descripcion", concepto.Descripcion);
                    cmd.Parameters.AddWithValue("@Importe", concepto.Importe);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new Exception($"No se pudo insertar concepto de venta renglon({concepto.Renglon})");
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
