using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    internal class BookDatabase : DbContext
    {
        private static BookDatabase _instance;

        private BookDatabase(string connectionString) : base(connectionString)
        {
            
        }

        private DbSet<Book> _books { get; }
        public static BookDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    string connectionString = ConnectionStringFactory.CreateConnectionStringToDatabase("DESKTOP-3NHSSF9", "DatabaseFirstExample");
                    _instance = new BookDatabase(connectionString);
                }

                return _instance;
            }
        }

    }
}
