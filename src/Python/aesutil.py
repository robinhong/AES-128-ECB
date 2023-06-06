from Crypto.Cipher import AES
import hashlib
import binascii


def aes_key(key):
    md5_object = hashlib.md5()
    md5_object.update(key.encode('utf-8'))
    return md5_object.hexdigest().upper()[8:24].encode('utf-8')


def aes_encrypt(data, key):
    cipher = AES.new(aes_key(key), AES.MODE_ECB)
    encrypted_text = cipher.encrypt(pkcs77padding(data))
    return binascii.hexlify(encrypted_text).decode().upper()


def aes_decrypt(data, key):
    cipher = AES.new(aes_key(key), AES.MODE_ECB)
    decrypted_text = cipher.decrypt(binascii.unhexlify(data)).rstrip(b'\0')
    return decrypted_text.decode()


def pkcs77padding(str):
    padding_length = 16 - len(str) % 16
    padded_text = str + padding_length * chr(padding_length)
    return padded_text.encode("utf-8")
