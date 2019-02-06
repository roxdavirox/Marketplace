namespace Marketplace.Shared
{
    public static class Settings
    {
        private static string _connectionString { get; set; }
        public static string SetConnectionString(string cs) => _connectionString = cs;
        public static string ConnectionString => _connectionString;

        public static string MediatRAssemblyName = "Marketplace.App";
    }
}
