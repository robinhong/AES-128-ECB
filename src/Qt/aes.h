#ifndef AES_H
#define AES_H

#include <QObject>
#include <QCryptographicHash>
#include "qaesencryption.h"

class Aes
{
public:
    Aes();

    // 密钥
    static QString AesKey(const QString &key);
    // 加密
    static QString AesEncrypt(const QString &data, const QString &key);
    // 解密
    static QString AesDecrypt(const QString &data, const QString &key);
};

#endif // AES_H
