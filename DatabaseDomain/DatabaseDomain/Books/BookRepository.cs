using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository() : base(BookDatabase.Instance)
        {

        }

        public Book GetBookWithTitle(string title)
        {
            return Entities.First(b => b.Title == title);
        }
    }
}
