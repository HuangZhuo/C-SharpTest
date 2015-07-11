using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
using System.Threading;

namespace C_SharpTest
{
    class TimerTest : TestInterface
    {
        int CountDown = 5;
        System.Timers.Timer Timer;
        public void Invoke()
        {
            Timer = new System.Timers.Timer(1000);
            Timer.Elapsed += timer_Elapsed;
            Timer.Disposed += timer_Disposed;
            Timer.Start();
            Timer.Enabled = true;

            Console.ReadLine(); //阻塞主线程
        }

        void timer_Disposed(object sender, EventArgs e)
        {
            System.Console.WriteLine("Time Up");
            //throw new NotImplementedException();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CountDown--;
            System.Console.WriteLine(e.SignalTime);
            if (0 == CountDown)
            {
                Timer.Dispose();
            }

            //throw new NotImplementedException();
        }
    }
}

// https://msdn.microsoft.com/zh-cn/library/system.timers.timer.aspx
