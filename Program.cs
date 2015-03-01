using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{
    class Program : TestInterface
    {
        static void Main(string[] args)
        {
            TestInterface handle = new DelegateTest();
            handle.Invoke();
        }

        public void Invoke()
        {
            //Console.WriteLine("hello");
            int i = 1;
            object o = i;

            i = (int)o;
        }
    }
}
