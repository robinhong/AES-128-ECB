<?php
header("Content-Type:text/html;charset=UTF-8");

require 'aesutil.php';

$data = "hello world";
$key = "anyaeskey";

console_log("明文: " . $data);
console_log("密钥: " . $key);

$encryptedData = AesUtil::aes_encrypt($data, $key);
console_log("密文: " . $encryptedData);

$decryptedData = AesUtil::aes_decrypt($encryptedData, $key);
console_log("解密后的明文: " . $decryptedData);


$aeskey = AesUtil::aes_key($key);
console_log("key: " . $aeskey);

console_log("MD5: " . hash('MD5', $key));


function console_log($str)
{
    echo $str . "\r\n";
}
