using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain
{
    public class JsonHelper
    {
        public static string MakeJsonReadable(string jsonString)
        {
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string formattedJson = JsonSerializer.Serialize(document.RootElement, options);


                return formattedJson;
            }
        }


    }

}
