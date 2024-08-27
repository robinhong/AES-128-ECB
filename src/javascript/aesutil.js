// 安装依赖库
// cnpm install crypto-js --save

import CryptoJS from "crypto-js";

//密钥
function aesKey(key) {
    return CryptoJS.enc.Utf8.parse(CryptoJS.MD5(key).toString().substring(8, 24).toUpperCase());
}

// AES-128-ECB 加密函数
function aesEncrypt(data, key) {
    var ciphertext = CryptoJS.enc.Utf8.parse(data);
    var encrypted = CryptoJS.AES.encrypt(ciphertext, aesKey(key), { mode: CryptoJS.mode.ECB });
    return encrypted.ciphertext.toString(CryptoJS.enc.Hex).toUpperCase();
}

// AES-128-ECB 解密函数
function aesDecrypt(data, key) {
    var ciphertext = CryptoJS.enc.Hex.parse(data);
    var decrypted = CryptoJS.AES.decrypt({ ciphertext: ciphertext }, aesKey(key), { mode: CryptoJS.mode.ECB });
    return decrypted.toString(CryptoJS.enc.Utf8);
}

export const AesUtil = {
    aesKey,
    aesEncrypt,
    aesDecrypt
}