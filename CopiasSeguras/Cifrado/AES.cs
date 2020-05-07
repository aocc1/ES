using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace CopiasSeguras.Cifrado
{
    class AES
    {
        public static Byte[] AESCrypto(String modo, byte[] archivo, String path, string key) {

            using (var aes = new AesCryptoServiceProvider())
            {

                //aes.GenerateIV();
                //aes.GenerateKey();

                aes.IV = System.Text.Encoding.UTF8.GetBytes("ivProvisional16-");
                //aes.Key = System.Text.Encoding.UTF8.GetBytes("keyProvisional32----------------");
                aes.Key = System.Text.Encoding.UTF8.GetBytes(key);

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = null;

                    if (modo == "Encriptar")
                        cryptoStream = new CryptoStream(memStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    else if (modo == "Desencriptar")
                        cryptoStream = new CryptoStream(memStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    if (cryptoStream == null)
                        return null;

                    cryptoStream.Write(archivo, 0, archivo.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(path, memStream.ToArray());
                    return memStream.ToArray();
                }
            }
            //return null;
        }

    }
}
