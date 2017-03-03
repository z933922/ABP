using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Zz.Web
{
    public class TestAsy
    {
        public string Method(string str)
        {
            return Thread.CurrentThread.ManagedThreadId + str + "你是个大傻逼";
        }
    }
}