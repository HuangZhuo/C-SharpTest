using System;
using System.Collections.Generic;


namespace C_SharpTest
{
    class SimpleStack
    {
        Entry mTop = null;

        public void Push(object data)
        {
            mTop = new Entry(mTop, data);
        }

        public object Pop()
        {
            if (mTop == null)
            {
                throw new InvalidOperationException();
            }
            object ret = mTop.Data;
            mTop = mTop.Next;
            return ret;
        }

        class Entry
        {
            public Entry Next;
            public object Data;

            public Entry(Entry next, object data) //在头部插入
            {
                this.Next = next;
                this.Data = data;
            }
        }
    }

}
