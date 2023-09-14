using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observer
{
    public class RequestPublisher : List<IRequestHandler>
    {
   

        public object PublishRequest(string request)
        {
            foreach (var requestHandler in this)
            {
               var response = requestHandler.HandleRequest(request);
               if (response != null) return response;
            }

            return null;
        }

    }
}
