using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain.Network
{
    public interface IRequestHandler<T>
    {
        object HandleRequest(T request);
    }

    public interface IRequestHandler
    {
        object HandleRequest(string request);
    }
}
