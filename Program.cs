
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
            System.Console.Write("Main");

            //TestInterface handle = new Net1();
            //handle.Invoke();

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
