using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Observer
{
    public interface IRequestHandler
    {
        object HandleRequest(string request);
    }

    public interface IRequestHandler<T>
    {
        object HandleRequest(T request);
    }
}
