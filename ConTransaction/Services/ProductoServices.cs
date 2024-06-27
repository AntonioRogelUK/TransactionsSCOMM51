using ConTransaction.Commands;
using ConTransaction.Database;
using System;
using System.Data.SqlClient;

namespace ConTransaction.Services
{
    internal class ProductoServices
    {
        public void AltaProducto(string nombre, decimal precio, int cantidadInicial)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuracion.ConnectionString))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();

                    try
                    {
                        ProductosCommands productosCommands = new ProductosCommands();
                        productosCommands.AltaProducto(con, tran, nombre, precio, cantidadInicial);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Error al dar de alta el producto: " + ex.Message);
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
