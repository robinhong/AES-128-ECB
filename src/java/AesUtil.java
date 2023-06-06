import java.security.MessageDigest;
import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class AesUtil {
    // 十六进制转字节数组
    private static byte[] hexToBytes(String hexString) {
        int len = hexString.length();
        // 若长度不是偶数加一个前导0
        if (len % 2 != 0) {
            hexString = "0" + hexString;
            len++;
        }
        byte[] bytes = new byte[len / 2];
        for (int i = 0; i < len; i += 2) {
            bytes[i / 2] = (byte) ((Character.digit(hexString.charAt(i), 16) << 4)
                    + Character.digit(hexString.charAt(i + 1), 16));
        }
        return bytes;
    }

    // 字节数组转十六进制
    public static String bytesToHex(byte[] bytes) {
        StringBuilder hexString = new StringBuilder();
        for (byte b : bytes) {
            hexString.append(String.format("%02X", b));
        }
        return hexString.toString();
    }

    // Md5加密
    public static String Md5(String content) throws Exception {
        MessageDigest md = MessageDigest.getInstance("MD5");
        byte[] bytes = md.digest(content.getBytes("utf-8"));
        return bytesToHex(bytes).toUpperCase();
    }

    // key先转成16位Md5值
    private static SecretKeySpec AesKey(String key) throws Exception {
        return new SecretKeySpec(Md5(key).substring(8, 24).toUpperCase().getBytes(), "AES");
    }

    // 加密
    public static String AesEncrypt(String data, String key) throws Exception {
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.ENCRYPT_MODE, AesKey(key));
        byte[] encryptedBytes = cipher.doFinal(data.getBytes("utf-8"));
        return bytesToHex(encryptedBytes).toUpperCase();
    }

    // 解密
    public static String AesDecrypt(String data, String key) throws Exception {
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, AesKey(key));
        byte[] decryptedBytes = cipher.doFinal(hexToBytes(data));
        data = new String(decryptedBytes, "utf-8");
        return data;
    }
}