using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain.Players
{
    public class PlayerProfile
    {

        public int Id { get; set; }

        public DateTime TotalPlayTime { get; set; }

        public void IncreasePlayTime(TimeSpan timeSpan)
        {
            TotalPlayTime.Add(timeSpan);
        }

        public TimeSpan TotalPlayTimeInTimeSpan
        {
            get
            {
                return DateTimeConverter.ConvertToTimeSpan(TotalPlayTime);
            }
        }
    }
}
