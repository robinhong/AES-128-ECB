<?php
header("Content-Type:text/html;charset=UTF-8");

require 'aes.php';

$data = "hello world";
$key = "anyaeskey";

console_log("明文: " . $data);
console_log("密钥: " . $key);

$encryptedData = aes_encrypt($data, $key);
console_log("密文: " . $encryptedData);

$decryptedData = aes_decrypt($encryptedData, $key);
console_log("解密后的明文: " . $decryptedData);


function console_log($str)
{
    echo $str . "\r\n";
}
