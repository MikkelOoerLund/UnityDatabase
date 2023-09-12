using DatabaseDomain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class Test
    {

        public PlayerProfile[] PlayerProfiles()
        {
            string connectionString = ConnectionStringFactory.CreateConnectionStringToDatabase("DESKTOP-3NHSSF9", "PlantVsZombies");

            PlayerDatabase playerDatabase = new PlayerDatabase(connectionString);

            PlayerProfile[] playerProfiles;

            using (PlayerProfileRepository repository = new PlayerProfileRepository(playerDatabase))
            {
                repository.Add(new PlayerProfile());

                repository.Update();


                playerProfiles = repository.GetAll().ToArray();

                //foreach (var item in repository.GetAll().ToArray())
                //{
                //    Console.WriteLine($"ID: {item.Id}, TotalPlayTime: {DateTimeConverter.ConvertToTimeSpan(item.TotalPlayTime)}");
                //}

            }

            return playerProfiles;

        }

    }
}
