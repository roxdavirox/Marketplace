namespace Marketplace.Shared
{
    public static class Settings
    {
        public readonly static string ConnectionString =
            @"Data Source=.\SQLEXPRESS;Initial Catalog=Marketplace;Integrated Security=True";

        public static string GetConnectionString(string catalog) =>
            $@"Data Source=.\SQLEXPRESS;Initial Catalog={catalog};Integrated Security=True";

        public static string MediatRAssemblyName = "Marketplace.App";
    }
}
