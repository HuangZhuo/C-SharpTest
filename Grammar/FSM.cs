using System;
using System.Collections.Generic;

namespace C_SharpTest
{
    public class State
    {
        public Action onEnter;
        public Action onExit;
        public Action<float> onUpdate;
    }

    /// <summary>
    /// 一个简单的状态机
    /// </summary>
    public class FSM
    {
        State mCurSate = null; //当前状态
        float mTime = 0f; //当前状态持续时间
        public State curState
        {
            get { return mCurSate; }
            set
            {
                if (mCurSate == value) //同一状态不允许重复进入
                    return;
                if (mCurSate != null && mCurSate.onExit != null)
                    mCurSate.onExit();
                mTime = 0;
                mCurSate = value;
                if (mCurSate != null && mCurSate.onEnter != null)
                    mCurSate.onEnter();
            }
        }

        public void LogicUpdate(float deltaTime)
        {
            mTime += deltaTime;
            if (mCurSate != null && mCurSate.onUpdate != null)
                mCurSate.onUpdate(deltaTime);
        }
    }

    public class FSMTest : TestInterface
    {
        void print(string s)
        {
            System.Console.WriteLine(s);
        }

        public void Invoke()
        {
            var fsm = new FSM();

            State eat = new State();
            eat.onEnter += () => { print("开始吃饭"); };
            eat.onUpdate += (float dt) => { print("正在吃饭"); };
            eat.onExit += () => { print("吃完了"); };

            State sleep = new State();
            sleep.onEnter += () => { print("开始睡觉"); };
            sleep.onUpdate += (float dt) => { print("zzzZ"); };
            sleep.onExit += () => { print("睡醒了"); };

            Random rd = new Random();
            while (true)
            {
                var n = rd.Next(2, 4); //可取下限，不能取上限
                if (n == 2)
                    fsm.curState = eat;
                else
                    fsm.curState = sleep;
                fsm.LogicUpdate(n);
                System.Threading.Thread.Sleep(n * 500);
            }
        }
    }
}