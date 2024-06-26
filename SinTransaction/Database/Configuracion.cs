namespace SinTransaction.Database
{
    internal static class Configuracion
    {
        public static string ConnectionString { get; private set; }
            = "Server=localhostt;Database=TransactionDB;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
