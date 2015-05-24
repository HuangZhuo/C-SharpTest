using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{
    class ADTEST : TestInterface
    {
        public void Invoke()
        {
            TestStack();
        }

        void TestStack()
        {
            var stack = new SimpleStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
        }
    }

}
