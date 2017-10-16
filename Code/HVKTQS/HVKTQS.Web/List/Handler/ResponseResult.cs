using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HVKTQS.Web
{
    public class ResponseResult
    {
        public string d { set; get; }
        public string msg { set; get; }
        public bool hasExecuted { set; get; }

        public int c { set; get; } = 1;
    }
}