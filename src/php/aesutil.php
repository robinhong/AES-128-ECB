<?php
class AesUtil
{
    public static function aes_key($key): string
    {
        return strtoupper(substr(hash('MD5', $key), 8, 16));
    }

    public static function aes_encrypt($data, $key): string
    {
        return strtoupper(bin2hex(openssl_encrypt($data, 'AES-128-ECB', self::aes_key($key), OPENSSL_RAW_DATA)));
    }

    public static function aes_decrypt($data, $key): string
    {
        return openssl_decrypt(hex2bin($data), 'AES-128-ECB', self::aes_key($key), OPENSSL_RAW_DATA);
    }
}
