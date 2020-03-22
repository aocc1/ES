using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
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
            Console.WriteLine(ArchivoaCifrar.Text);
    
            byte[] archivoACifrar = File.ReadAllBytes(ArchivoaCifrar.Text);

            AES cifrador = new AES();
            Aes myAes = Aes.Create() ;

           cifrador.EncryptStringToBytes_Aes(archivoACifrar , myAes.Key , myAes.IV);
        }
    }
}
