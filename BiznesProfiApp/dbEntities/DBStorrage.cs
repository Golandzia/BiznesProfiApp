using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesProfiApp.dbEntities
{
    public static class DBStorrage
    {
        public static BiznesProfiAppDBEntities DB_s { get; set; } = new BiznesProfiAppDBEntities();
    }
}
