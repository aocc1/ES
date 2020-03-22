using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using CopiasSeguras.Cifrado;

namespace CopiasSeguras
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void SlecArchivoButton_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fbd = new FolderBrowserDialog(); esto es para carpetas
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ArchivoaCifrar.Text = ofd.FileName;



        }

        private void SelecDescButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); 
           
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                rutaDesc.Text = fbd.SelectedPath;

        }

        private void cifra_Click(object sender, EventArgs e)
        {
            String path = ArchivoaCifrar.Text;
            byte[] archivoCifrar = File.ReadAllBytes(path);

            AES cifrador = new AES();

            using (var aes = new AesCryptoServiceProvider())
            {
                aes.GenerateIV();
                aes.GenerateKey();

                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                byte[] encriptado = AES.AESCrypto("Encriptar", aes, archivoCifrar);

                
                Console.WriteLine(System.Text.Encoding.UTF8.GetString(AES.AESCrypto("Encriptar", aes, archivoCifrar)));
                Console.WriteLine(encriptado);
            }


            /*
            AES cifrador = new AES();
            using (Aes myAes = Aes.Create())
            {
                // Encrypt the string to an array of bytes.
                cifrador.EncryptStringToBytes_Aes(archivoCifrar, myAes.Key, myAes.IV);

            }
            */
        }
    }
}
