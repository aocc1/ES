using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CopiasSeguras.Cifrado
{
    class RSA
    {
        public static Byte[] RSACrypto(String modo, byte[] archivo, String path)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                RSAParameters publicKey = rsa.ExportParameters(false);
                RSAParameters privateKey = rsa.ExportParameters(true);

                using (var memStream = new MemoryStream())
                {
                    CryptoStream cryptoStream = null;

                    if (modo == "Encriptar")
                    {
                        rsa.ImportParameters(publicKey);
                        byte[] encrypted = rsa.Encrypt(archivo, true);
                        //cryptoStream = new CryptoStream(memStream, encrypted, CryptoStreamMode.Write);
                    }
                    else if (modo == "Desencriptar")
                    {
                        rsa.ImportParameters(privateKey);
                        byte[] decrypted = rsa.Encrypt(archivo, true);
                        //cryptoStream = new CryptoStream(memStream, decrypted, CryptoStreamMode.Write);
                    }
                    if (cryptoStream == null)
                    {
                        return null;
                    }

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
