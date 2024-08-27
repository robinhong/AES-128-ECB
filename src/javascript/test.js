import { AesUtil } from './aesutil.js';

var data = "hello world";
var key = "anyaeskey";

console.log("明文: " + data);
console.log("密钥: " + key);

var encryptedData = AesUtil.aesEncrypt(data, key);
console.log("密文: " + encryptedData);

var decryptedData = AesUtil.aesDecrypt(encryptedData, key);
console.log("解密后的明文: " + decryptedData);