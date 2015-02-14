using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var handle = new DelegateTest();
            handle.Invoke();
                        
        }

        void Invoke()
        {
            Console.WriteLine("hello");
        }
    }
}
