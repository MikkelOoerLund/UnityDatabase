using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observer
{
    public class RequestPublisher : Dictionary<Type, List<IRequestHandler>>
    {
        public void Add<T>(IRequestHandler<T> requestHandler)
        {
            Type type = typeof(T);

            if (ContainsKey(type))
            {
                this[type].Add(requestHandler);
                return;
            }

            this[type] = new List<IRequestHandler>()
            {
                requestHandler,
            };

        }

        public object PublishRequest<T>(T request)
        {
            Type type = typeof(T);

            foreach (var requestHandler in this[type])
            {
               var response = requestHandler.HandleRequest(request);
               if (response != null) return response;
            }

            throw new Exception($"Request {request} was not handled");
        }

    }
}
