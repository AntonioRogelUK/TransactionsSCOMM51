using ConTransaction.Commands;
using ConTransaction.Database;
using System;
using System.Data.SqlClient;

namespace ConTransaction.Services
{
    internal class ClienteServices
    {
        public void AltaCliente(string nombre, string correo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    con.Open();

                    ClientesCommands clientesCommands = new ClientesCommands();
                    clientesCommands.AltaCliente(con, nombre, correo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el cliente: " + ex.Message);
            }
        }
    }
}