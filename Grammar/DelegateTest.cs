using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{

    delegate int TwoIntsOp(int a, int b); //定义一个委托

    delegate object MyDelegate();
    delegate void MyDelegate2(string str);


    // PDF_159
    public class DelegateTest : TestInterface
    {
        string str = "This is a member in DelegateTest";

        public void Invoke()
        {
            Test2();
        }

        void Test1()
        {
            TwoIntsOp f = new TwoIntsOp(add); //这种行为貌似执行了C++中的std::bind绑定了this指针
            Console.WriteLine(f(1, 2));

            TwoIntsOp f2 = (a, b) => { return a + b; }; // 不需要指定参数类型，因为编译器知道的！
            TwoIntsOp f2_2 = (a, b) => a + b; // 实现只有一句话，可以简写。
            Console.WriteLine(f2_2(2, 3));

            TwoIntsOp f3 = f + f2; // 多播委托
            Console.WriteLine(f3(3, 4));

            TwoIntsOp f4 = f3 + blabla; // 多播委托中抛出异常，停止迭代。
            try
            {
                f4(4, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(f4.GetInvocationList().Length); // 获取迭代方法列表，输出3。用处：手动迭代，每次迭代捕获异常，让循环继续进行。

            TwoIntsOp f5 = delegate(int a, int b) { Console.WriteLine(str); return 0; }; // 试用匿名方法，并在访问匿名方法外面定义的变量。
            f5(5, 6); // 匿名方法和lambda表达式对于编译器生成的IL（中间语言）是一样的？
        }

        // 协变和逆变
        void Test2()
        {
            MyDelegate md = () => { return "sss"; }; //这就是协变：string是object的子类。
            Console.WriteLine(md());

            // 下面是逆变
            MyDelegate2 md2 = foo; //奇怪：这个地方不能使用lambda了....
            md2("mmm");
        }

        // 事件：.NET把Windows消息封装在事件中，并让用户无需理解底层的委托。
        void Test3()
        {

        }

        void foo(object obj) { Console.WriteLine(obj.ToString()); }

        public int add(int a, int b)
        {
            return a + b;
        }

        public int blabla(int a, int b)
        {
            throw new Exception(">_<");
        }
    }

}
// 定义委托，类似于用typedef定义一个新类型。
// 对象是类的实例，而委托的实例仍然叫做委托。委托的含义要通过上下文确定:)
// 