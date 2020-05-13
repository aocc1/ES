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
        //Tamaño de clave RSA
        static int size = 2048;
        //1 para RSA, 13 para DSA
        static int rsa_provider = 1;
        //Nombre del contenedor de las claves
        static String containerName = "MiContenedor";

        //Genera las keys en un contenedor seguro
        public static void generateRSAKeys()
        {
            CspParameters cspParameters = new CspParameters(rsa_provider);
            cspParameters.KeyContainerName = containerName;
            cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParameters.ProviderName = "Microsoft Strong Cryptographic Provider";
            var rsa = new RSACryptoServiceProvider(cspParameters);
            rsa.PersistKeyInCsp = true;
        }

        //Encripta un los datos de un archivo dada su ruta y lo gurada de nuevo en el archivo
        public static byte[] RSAEncrypt(byte[] archivo, String path)
        {
            byte[] dataEncrypted;
            CspParameters cspParameters = new CspParameters(rsa_provider);
            cspParameters.KeyContainerName = containerName;
            using (var rsa = new RSACryptoServiceProvider(size, cspParameters))
            {
                dataEncrypted = rsa.Encrypt(archivo, true);
                File.WriteAllBytes(path, dataEncrypted);

            }
            return dataEncrypted;
        }

        //Desencripta un los datos de un archivo dada su ruta y lo gurada de nuevo en el archivo
        public static byte[] RSADecrypt(byte[] archivo, String path)
        {
            byte[] dataDecrypted;
            CspParameters cspParameters = new CspParameters();
            cspParameters.KeyContainerName = containerName;
            using (var rsa = new RSACryptoServiceProvider(size, cspParameters))
            {
                dataDecrypted = rsa.Decrypt(archivo, true);
                File.WriteAllBytes(path, dataDecrypted);

            }
            return dataDecrypted;
        }
    }
}
