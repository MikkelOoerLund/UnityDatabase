using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class StringHelper
    {

        public static int GetIntegerFromString(string value)
        {
            if (value == null) return 0;

            var pattern = @"(\d+(\.\d+)?)";
            var matches = Regex.Matches(value, pattern);

            foreach (Match match in matches)
            {
                var numberString = match.Value;
                if (int.TryParse(numberString, out int number))
                {
                    return number;
                }
            }

            throw new Exception();
        }


        public static string InsertSpaceBeforeUppercase(string input)
        {
            string pattern = @"(\p{Lu})";
            string replacement = " $1";
            string result = Regex.Replace(input, pattern, replacement);

            return result.Trim();
        }
    }
}
