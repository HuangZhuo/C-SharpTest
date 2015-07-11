using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace C_SharpTest
{
    [Serializable]
    public class LoginConfig
    {
        private string mName;
        private string mPwd;
        private const string mFilePath = "Login.dat";

        public static LoginConfig Inst = new LoginConfig();
        public static string UserName { get { return Inst.mName; } set { Inst.mName = value; } }
        public static string UserPwd { get { return Inst.mPwd; } set { Inst.mPwd = value; } }

        public static void Save()
        {
            Inst.Serialize();
        }

        public static void Load()
        {
            Inst.Deserialize();
        }

        private LoginConfig() { }

        private void Serialize()
        {
            var fs = new FileStream(mFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        private void Deserialize()
        {
            var fs = new FileStream(mFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var bf = new BinaryFormatter();
            var obj = (LoginConfig)bf.Deserialize(fs);
            this.mName=obj.mName;
            this.mPwd = obj.mPwd;
            fs.Close();
        }
    }

    class SerializationTest : TestInterface
    {
        public void Invoke()
        {
            //LoginConfig.UserName = "Zhuo";
            //LoginConfig.UserPwd = "123456";
            //LoginConfig.Save();

            LoginConfig.Load();
            var tmp = LoginConfig.Inst;
        }
    }
}
