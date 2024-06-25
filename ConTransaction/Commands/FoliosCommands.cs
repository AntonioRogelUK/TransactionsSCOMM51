using System;
using System.Data.SqlClient;

namespace ConTransaction.Commands
{
    internal class FoliosCommands
    {
        public int ObtenerSiguienteFolio(SqlConnection con, SqlTransaction transaction)
        {
            try
            {

                string query = "Select FolioActual + 1 from Folios";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = transaction;
                    var resultado = cmd.ExecuteScalar();
                    int foliosiguiente = 0;
                    bool sePudoConvertir = false;
                    sePudoConvertir = int.TryParse(resultado.ToString(), out foliosiguiente);
                    if (!sePudoConvertir)
                    {
                        throw new Exception("No se pudo obtener el folio");
                    }
                    return foliosiguiente;

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ActualizarFolio(SqlConnection con, SqlTransaction transaction)
        {
            try
            {

                string query = "Update Folios set FolioActual = FolioActual + 1 ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Transaction = transaction;
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas == 0)
                    {
                        throw new Exception("No se pudo actualizar el folio");
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
