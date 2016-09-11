using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpTest
{

    public class OrderInfo: ICloneable
    {
        public int ID;
        public string receiptData;
        public int timeStap;

        public object Clone()
        {
            return this.MemberwiseClone();

            //var tmp = new OrderInfo();
            //tmp.ID = ID;
            //tmp.receiptData = receiptData.Clone() as string;
            //tmp.timeStap = timeStap;
            //return tmp;
        }
    }

    public class OrderCache
    {
        public string desc;
        public List<OrderInfo> orders;
    }

    /// <summary>
    /// 使用json保存订单数据
    /// </summary>
    class JsonTest: TestInterface
    {
        public void Invoke()
        {
            var str = TestSave();
            Program.Print(str);
            TestLoad(str);
        }

        public string TestSave()
        {
            var order = new OrderInfo();
            order.ID = 1;
            order.receiptData = "test1";
            order.timeStap = (int)DateTime.Now.DayOfYear;

            var cache = new OrderCache();
            cache.desc = "This are cached orders.";
            cache.orders = new List<OrderInfo>();
            cache.orders.Add(order);

            order = order.Clone() as OrderInfo;
            order.ID = 2;
            order.receiptData = "test2";
            cache.orders.Add(order);

            return LitJson.JsonMapper.ToJson(cache);
        }

        public void TestLoad(string jsonStr)
        {
            var cache = LitJson.JsonMapper.ToObject<OrderCache>(jsonStr);
        }
    }
}

// http://www.w3school.com.cn/json/json_syntax.asp