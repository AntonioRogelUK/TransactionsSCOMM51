using ConTransaction.Entities;
using System;
using System.Data.SqlClient;

namespace ConTransaction.Commands
{
    internal class VentaCommand
    {
        public int GuardarVenta(SqlConnection con, SqlTransaction transaction, Venta venta)
        {
            try
            {

                string query = "insert into Ventas" +
                    "(Folio,Fecha,Cliente,Total) " +
                    "values" +
                    "(@Folio,getDate(),@Cliente,@Total); Select Scope_Identity()";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                    cmd.Parameters.AddWithValue("@Cliente", venta.Cliente);
                    cmd.Parameters.AddWithValue("@Total", venta.Total);

                    var resultado = cmd.ExecuteScalar();
                    bool sePudoConvertir = int.TryParse(resultado.ToString(), out int ventaId);
                    if (sePudoConvertir == false)
                    {
                        throw new Exception($"No se pudo insertar venta folio:{venta.Folio}");
                    }
                    return ventaId;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
