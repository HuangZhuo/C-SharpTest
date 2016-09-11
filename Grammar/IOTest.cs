using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_SharpTest
{
    class IOTest : TestInterface
    {
        public void Invoke()
        {
            Test1();
        }

        void Test1()
        {
            // read file
            FileStream fs = new FileStream("myFile.txt", FileMode.OpenOrCreate);
            string text = @"https://msdn.microsoft.com/zh-cn/library/system.io.filestream(v=vs.110).aspx";
            byte[] buff = System.Text.Encoding.UTF8.GetBytes(text);
            fs.Write(buff, 0, buff.Length);
            fs.Close();

            // write file
            buff = new byte[1024];
            fs = new FileStream("myFile.txt", FileMode.Open);
            fs.Read(buff, 0, 1024);
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(buff));
            fs.Close();


            var stopwatch = new System.Diagnostics.Stopwatch();
            string fileName = "";
            using (var st = File.Open(fileName, FileMode.OpenOrCreate))
            {
                stopwatch.Start();
            }

            // streamReader:方便用来处理文本文件
            var sr= File.OpenText("myFile.txt");
            sr.ReadToEnd();


        }
    }
}
