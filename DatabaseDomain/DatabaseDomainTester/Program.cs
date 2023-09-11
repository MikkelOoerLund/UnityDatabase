using DatabaseDomain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomainTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BookRepository repository = new BookRepository())
            {
                repository.Add(new Book()
                {
                    Title = "Firkant",
                });

                repository.Update();

                foreach (var book in repository.GetAll())
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
                }
            }



            Console.ReadKey();

        }
    }
}
