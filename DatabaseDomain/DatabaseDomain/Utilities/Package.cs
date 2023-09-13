using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class Package
    {
        public string Message { get; set; }
        public string Data { get; set; }

        public T GetDataObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(Data);
        }
    }
}
