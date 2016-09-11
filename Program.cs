
namespace C_SharpTest
{
    class Program : TestInterface
    {
        static Program()
        {
            System.Console.WriteLine("Test Begin");
        }

        static void Main(string[] args)
        {
            TestInterface handle = new JsonTest();
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

        public static void Print(string str)
        {
            System.Console.WriteLine(str);
        }
    }
}
