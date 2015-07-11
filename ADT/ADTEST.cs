using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{
    class Student : IComparable<Student>
    {
        int age;
        string name;
        public int CompareTo(Student obj)
        {
            return age.CompareTo(obj.age);
        }
    }

    struct MyPair : ICloneable
    {
        public int A;
        public int B;

        public Dictionary<int, int> C;
        public MyPair(int a, int b)
        {
            A = a; B = b;
            C = new Dictionary<int, int>();
        }

        public object Clone()
        {
            MyPair tmp = new MyPair();
            tmp.C = new Dictionary<int, int>(C);
            return tmp;
        }
    }
    class ADTEST : TestInterface
    {

        public void Invoke()
        {
            //TestStack();
            SCG_ListTest2();
        }

        void TestStack()
        {
            var stack = new SimpleStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
        }

        void SCG_ListTest()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(3);
            list.Add(5);
            list.Insert(0, 0);

        }

        void SCG_ListTest2()
        {
            List<MyPair> list = new List<MyPair>();
            list.Add(new MyPair());
            MyPair p;
            p.A = 1; p.B = 2; p.C = new Dictionary<int, int>();
            list.Add(p);

            // https://msdn.microsoft.com/en-us/library/wydkhw2c(vs.71).aspx
            //list[1].A = 2;
            MyPair temp = list[1];
            temp.A = 2;
            list[1] = temp;

            MyPair p2 = new MyPair(4, 4);
            list.Add(p2);

            list[2].C.Add(666, 666);

            // http://stackoverflow.com/questions/3161705/create-an-arraylist-of-struct-in-c-sharp
            ArrayList arrayList = new ArrayList();
            arrayList.Add(p2);
            ((MyPair)arrayList[0]).C.Add(555, 555);
            
        }
    }

}
