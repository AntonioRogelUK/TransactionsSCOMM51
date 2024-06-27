using System;
using System.Data.SqlClient;

namespace ConTransaction.Commands
{
    internal class EmpleadosCommands
    {
        public void AltaEmpleado(SqlConnection con, string nombre, string puesto)
        {
            try
            {
                string query = @"INSERT INTO Empleados (Nombre, Puesto) 
                                 VALUES (@Nombre, @Puesto)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Puesto", puesto);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el empleado: " + ex.Message);
            }
        }
    }
}