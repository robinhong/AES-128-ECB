using System;

namespace Demo
{
    public class Test
    {
        static void Main(string[] args)
        {
            string data = "hello world";
            string key = "anyaeskey";

            Console.WriteLine("明文: " + data);
            Console.WriteLine("密钥: " + key);

            string encryptedData = AesUtil.AesEncrypt(data, key);
            Console.WriteLine("密文: " + encryptedData);

            string decryptedData = AesUtil.AesDecrypt(encryptedData, key);
            Console.WriteLine("解密后的明文: " + decryptedData);
        }
    }
}
