using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class ConnectionStringFactory
    {
        public static string CreateConnectionStringToDatabase(string dataSource, string database)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = database,
                IntegratedSecurity = true,
            };

            return builder.ConnectionString;
        }

    }
}
