
namespace C_SharpTest
{
    class Program : TestInterface
    {
        static Program()
        {
            System.Console.Write("hello");
        }

        static void Main(string[] args)
        {
            TestInterface handle = new FSMTest();
            handle.Invoke();

            System.Console.Read();
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
