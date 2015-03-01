using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace C_SharpTest
{
    class ThreadTest : TestInterface
    {
        public void Invoke()
        {
            int a,b;
            ThreadPool.GetMaxThreads(out a, out b);
            ThreadPool.QueueUserWorkItem((object state) => { System.Console.WriteLine(state); }, "param");
            Thread.Sleep(3000);
        }
    }
}
