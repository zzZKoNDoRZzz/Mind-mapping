using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace MindKeeperBase.Security
{
    public class Security
    {
        public static byte[] EncryptPassword(string login, string password)
        {
            string pass = login + "_" + password;
            UTF8Encoding textConverter = new UTF8Encoding();
            byte[] passBytes = textConverter.GetBytes(pass);
            return new SHA384Managed().ComputeHash(passBytes);
        }

        public static string Protect(string str)
        {
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            byte[] data = Encoding.ASCII.GetBytes(str);
            string protectedData = Convert.ToBase64String(ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser));
            return protectedData;
        }

        public static string Unprotect(string str)
        {
            byte[] protectedData = Convert.FromBase64String(str);
            byte[] entropy = Encoding.ASCII.GetBytes(Assembly.GetExecutingAssembly().FullName);
            string data = Encoding.ASCII.GetString(ProtectedData.Unprotect(protectedData, entropy, DataProtectionScope.CurrentUser));
            return data;
        }

        public static void SerializeProtectedString(string str, string filename)
        {
            FileStream stream = File.Create(filename);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, Protect(str));
            stream.Close();
        }

        public static string DeserializeProtectedString(string filename)
        {
            FileStream stream = File.OpenRead(filename);
            var formatter = new BinaryFormatter();
            var str = (string)formatter.Deserialize(stream);
            stream.Close();
            return Unprotect(str);
        }
    }
}
