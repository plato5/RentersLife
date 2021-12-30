using Microsoft.Data.SqlClient;

namespace RentersLife.Core.Data
{
    public sealed class DBConnection
    {
        private static DBConnection instance = null;
        private static string _connectionString;
        private DBConnection() 
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "renterslifeserver.database.windows.net";
            builder.UserID = "plato5";
            builder.Password = "Lewallen1971";
            builder.InitialCatalog = "RentersLifeDb";

            _connectionString = builder.ConnectionString;
        }

        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnection();
                }

                return instance;
            }
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
