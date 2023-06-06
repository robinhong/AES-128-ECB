public class test {
    public static void main(String[] args) throws Exception {

        String data = "hello world";
        String key = "anyaeskey";

        System.out.println("明文: " + data);
        System.out.println("密钥: " + key);

        String encryptedData = AesUtil.AesEncrypt(data, key);
        System.out.println("密文: " + encryptedData);

        String decryptedData = AesUtil.AesDecrypt(encryptedData, key);
        System.out.println("解密后的明文: " + decryptedData);
    }
}
