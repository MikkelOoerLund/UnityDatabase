using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public static class TextFileConverter
    {
        public static string ConvertToString(string textFilePath)
        {
            if (File.Exists(textFilePath) == false)
            {
                throw new FileNotFoundException(textFilePath);
            }

            return File.ReadAllText(textFilePath);
        }

    }
}
