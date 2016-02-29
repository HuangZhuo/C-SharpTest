using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{
    class Net1 : TestInterface
    {
        public void Invoke()
        {
            SynchronousSocketClient.StartClient();
        }

    }
}
