using System;
using System.Data.SqlClient;

namespace ConTransaction.Commands
{
    internal class ClientesCommands
    {
        public void AltaCliente(SqlConnection con, string nombre, string correo)
        {
            try
            {
                string query = @"INSERT INTO Clientes (Nombre, Correo) 
                                 VALUES (@Nombre, @Correo)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el cliente: " + ex.Message);
            }
        }
    }
}