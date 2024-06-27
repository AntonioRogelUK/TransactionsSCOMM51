using System;
using System.Data.SqlClient;

namespace ConTransaction.Commands
{
    internal class ProductosCommands
    {
        public void AltaProducto(SqlConnection con, SqlTransaction transaction, string nombre, decimal precio, int cantidadInicial)
        {
            try
            {
                string queryProducto = @"INSERT INTO Productos (Nombre, Precio) 
                                         VALUES (@Nombre, @Precio); 
                                         SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmdProducto = new SqlCommand(queryProducto, con, transaction))
                {
                    cmdProducto.Parameters.AddWithValue("@Nombre", nombre);
                    cmdProducto.Parameters.AddWithValue("@Precio", precio);
                    int ProductoId = Convert.ToInt32(cmdProducto.ExecuteScalar());

                    string queryExistencia = @"INSERT INTO Existencias (ProductoId, Cantidad) 
                                              VALUES (@ProductoId, @Cantidad)";
                    using (SqlCommand cmdExistencia = new SqlCommand(queryExistencia, con, transaction))
                    {
                        cmdExistencia.Parameters.AddWithValue("@ProductoId", ProductoId);
                        cmdExistencia.Parameters.AddWithValue("@Cantidad", cantidadInicial);
                        cmdExistencia.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el producto: " + ex.Message);
            }
        }
    }
}