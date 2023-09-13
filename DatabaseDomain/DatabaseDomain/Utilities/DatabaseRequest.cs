using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class DatabaseRequest
    {
        public QueryTask QueryTask { get; set; }
        public EntityTarget EntityTarget { get; set; }

        public DatabaseRequest()
        {

        }
        public DatabaseRequest(EntityTarget entityTarget, QueryTask queryTask)
        {
            this.QueryTask = queryTask;
            this.EntityTarget = entityTarget;
        }
    }

    public enum QueryTask
    {
        GetAll,
    }

    public enum EntityTarget
    {
        PlayerProfile,
    }

   

}
