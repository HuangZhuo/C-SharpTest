using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{

    delegate int TwoIntsOp(int a, int b);

    // PDF_159
    public class DelegateTest : TestInterface
    {
        int mCounts = 100;

        public void Invoke()
        {
            TwoIntsOp f = new TwoIntsOp(add);
            Console.WriteLine(f(1, 2));

            TwoIntsOp f2 = (a, b) => { return a + b; };
            Console.WriteLine(f2(2, 3));
        }

        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
