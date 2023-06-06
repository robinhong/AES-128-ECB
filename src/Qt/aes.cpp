#include "aes.h"

Aes::Aes()
{
}

QString Aes::AesKey(const QString &key)
{
    QByteArray md5Key = QCryptographicHash::hash(key.toUtf8(), QCryptographicHash::Md5);
    return md5Key.toHex().mid(8, 16).toUpper();
}

QString Aes::AesEncrypt(const QString &data, const QString &key)
{
    QAESEncryption encryption(QAESEncryption::AES_128, QAESEncryption::ECB, QAESEncryption::PKCS7);
    QByteArray enBA = encryption.encode(data.toUtf8(), AesKey(key).toUtf8());
    return enBA.toHex().toUpper();
}

QString Aes::AesDecrypt(const QString &data, const QString &key)
{
    QAESEncryption encryption(QAESEncryption::AES_128, QAESEncryption::ECB, QAESEncryption::PKCS7);
    QByteArray enBA = QByteArray::fromHex(data.toUtf8());
    QByteArray deBA = encryption.decode(enBA, AesKey(key).toUtf8());
    return QString::fromUtf8(QAESEncryption::RemovePadding(deBA, QAESEncryption::PKCS7));
}
