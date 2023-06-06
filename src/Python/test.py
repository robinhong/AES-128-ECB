import aesutil

data = "hello world"
key = "anyaeskey"

print("明文: " + data)
print("密钥: " + key)

encryptedData = aesutil.aes_encrypt(data, key)
print("密文: " + encryptedData)

decryptedData = aesutil.aes_decrypt(encryptedData, key)
print("解密后的明文: " + decryptedData)
