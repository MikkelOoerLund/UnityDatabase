using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class DatabaseRequest<TData>
    {
        public QueryTask QueryTask { get; set; }
        public EntityType EntityType { get; set; }

        public TData Data { get; set; }
    }





   

}
