using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public static class DateTimeConverter
    {
        private static DateTime _defaultDateTime = new DateTime();

        public static TimeSpan ConvertToTimeSpan(DateTime dateTime)
        {
            return dateTime - _defaultDateTime;
        }

    }
}
