using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain.Network
{
    public class RequestPublisher<T> : List<IRequestHandler<T>>
    {
        public RequestPublisher() : base()
        {

        }
        public RequestPublisher(IEnumerable<IRequestHandler<T>> requestHandlers) : base(requestHandlers)
        {

        }

        public object Publish(T request)
        {
            foreach (var requestHandler in this)
            {
                object response = requestHandler.HandleRequest(request);
                if (response != null) return response;
            }

            return null;
        }
    }


    public class RequestPublisher : List<IRequestHandler>
    {
        public RequestPublisher() : base()
        {

        }
        public RequestPublisher(IEnumerable<IRequestHandler> requestHandlers) : base(requestHandlers)
        {

        }

        public object Publish(string request)
        {
            foreach (var requestHandler in this)
            {
                object response = requestHandler.HandleRequest(request);
                if (response != null) return response;
            }

            return null;
        }
    }
}
