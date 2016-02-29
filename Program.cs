
namespace C_SharpTest
{
    class Program : TestInterface
    {
        static void Main(string[] args)
        {
            TestInterface handle = new Net1();
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
