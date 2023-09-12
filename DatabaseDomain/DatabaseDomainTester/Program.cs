using DatabaseDomain;
using DatabaseDomain.Players;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseDomainTester
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionString = ConnectionStringFactory.CreateConnectionStringToDatabase("DESKTOP-3NHSSF9", "PlantVsZombies");

            PlayerDatabase playerDatabase = new PlayerDatabase(connectionString);

            using (PlayerProfileRepository repository = new PlayerProfileRepository(playerDatabase))
            {
                repository.Add(new PlayerProfile());

                repository.Update();




                foreach (var item in repository.GetAll().ToArray())
                {
                    Console.WriteLine($"ID: {item.Id}, TotalPlayTime: {DateTimeConverter.ConvertToTimeSpan(item.TotalPlayTime)}");
                }

            }


            //using (BookRepository repository = new BookRepository())
            //{
            //    repository.Add(new Book()
            //    {
            //        Title = "Firkant",
            //    });

            //    repository.Update();

            //    foreach (var book in repository.GetAll())
            //    {
            //        Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
            //    }
            //}



            Console.ReadKey();

        }
    }
}
