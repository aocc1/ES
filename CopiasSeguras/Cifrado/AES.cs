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
        //Encripta o desencripta (segun el modo) mediante AES, dados los datos de un archivo, la ruta del mismo, y la clave (hasheada) del usuario
        public static Byte[] AESCrypto(String modo, byte[] archivo, String path, string key) {

            using (var aes = new AesCryptoServiceProvider())
            {
                aes.KeySize = 256;
                aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
                //El vector de inicializacion sera la primera mitad de la clave
                aes.IV = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, key.Length / 2));     
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

                    //Escribimos los datos encriptados en el archivo
                    cryptoStream.Write(archivo, 0, archivo.Length);
                    cryptoStream.FlushFinalBlock();
                    File.WriteAllBytes(path, memStream.ToArray());
                    return memStream.ToArray();
                }
            }
        }
    }
}
