using ConTransaction.Commands;
using ConTransaction.Database;
using System;
using System.Data.SqlClient;

namespace ConTransaction.Services
{
    internal class EmpleadoServices
    {
        public void AltaEmpleado(string nombre, string puesto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    con.Open();

                    EmpleadosCommands empleadosCommands = new EmpleadosCommands();
                    empleadosCommands.AltaEmpleado(con, nombre, puesto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el empleado: " + ex.Message);
            }
        }
    }
}