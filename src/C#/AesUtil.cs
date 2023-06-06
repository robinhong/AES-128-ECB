using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesUtil
{

    public static string ByteArrayToHexString(byte[] byteArray)
    {
        StringBuilder hexString = new StringBuilder();
        foreach (byte b in byteArray)
        {
            hexString.AppendFormat("{0:X2}", b);
        }
        return hexString.ToString();
    }

    public static byte[] HexStringToByteArray(string hexStr)
    {
        if (hexStr.Length % 2 != 0)
        {
            hexStr = "0" + hexStr;
        }
        byte[] bytes = new byte[hexStr.Length / 2];
        for (int i = 0; i < hexStr.Length; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hexStr.Substring(i, 2), 16);
        }
        return bytes;
    }

    public static string AesKey(string key)
    {
        using (var md5 = MD5.Create())
        {
            return ByteArrayToHexString(md5.ComputeHash(Encoding.UTF8.GetBytes(key))).ToUpper().Substring(8, 16);
        }
    }

    public static string AesEncrypt(string data, string key)
    {

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = UTF8Encoding.UTF8.GetBytes(AesKey(key));
            aesAlg.Mode = CipherMode.ECB;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, null);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(data);
                    }
                }
                return ByteArrayToHexString(msEncrypt.ToArray());
            }
        }
    }

    public static string AesDecrypt(string data, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = UTF8Encoding.UTF8.GetBytes(AesKey(key));
            aesAlg.Mode = CipherMode.ECB;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, null);

            using (MemoryStream msDecrypt = new MemoryStream(HexStringToByteArray(data)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}