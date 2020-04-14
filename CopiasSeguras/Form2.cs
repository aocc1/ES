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
using System.Text.Json;
using System.Text.Json.Serialization;

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

        private void botonEncriptar_Click(object sender, EventArgs e)
        {
            //String path = ArchivoaCifrar.Text;

            String path = @"C:\Users\Sergio Yáñez Cánovas\Desktop\Nueva carpeta";
            zip zip = new zip();
            zip.Comprimir(path);
            path = path + ".zip";

            byte[] ArchivoCifrar = File.ReadAllBytes(path);

            AES cifrador = new AES();

            string jsonString;
            jsonString = JsonSerializer.Serialize(Encoding.UTF8.GetString(ArchivoCifrar));

            byte[] serilizado = Encoding.UTF8.GetBytes(jsonString);

            byte[] encriptado = AES.AESCrypto("Encriptar", ArchivoCifrar, path);

            Console.WriteLine(System.Text.Encoding.UTF8.GetString(encriptado));
            Console.WriteLine(jsonString);
        }

        private void botonDesencriptar_Click(object sender, EventArgs e)
        {
            //String path = ArchivoaDescifrar.Text;

            String pathZip = @"C:\Users\Sergio Yáñez Cánovas\Desktop\Nueva carpeta.zip";
            zip zip = new zip();
            zip.Descomprimir(pathZip);
            string path = pathZip.Remove(pathZip.Length - 4, 4);

            byte[] ArchivoDescifrar = File.ReadAllBytes(path);

            AES cifrador = new AES();

            string jsonString;
            jsonString = JsonSerializer.Serialize(Encoding.UTF8.GetString(ArchivoDescifrar));

            byte[] serilizado = Encoding.UTF8.GetBytes(jsonString);

            byte[] desencriptado = AES.AESCrypto("Desencriptar", ArchivoDescifrar, path);

            Console.WriteLine(System.Text.Encoding.UTF8.GetString(desencriptado));
            Console.WriteLine(jsonString);
        }

        private void botonMenuDescifra_Click(object sender, EventArgs e)
        {
            panelCifrado.Hide();
            panelDescarga.Hide();
            panelSubir.Hide();
            panelDesencriptado.Show();

        }

        private void botonMenuDescarga_Click(object sender, EventArgs e)
        {
            panelCifrado.Hide();
            panelDesencriptado.Hide();
            panelSubir.Hide();
            panelDescarga.Show();
            
        }

        private void botonMenuCifra_Click(object sender, EventArgs e)
        {
            
            panelDescarga.Hide();
            panelDesencriptado.Hide();
            panelSubir.Hide();
            panelCifrado.Show();
        }

 

        private void SlecArchicvoDesc_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ArchivoaDescifrar.Text = ofd.FileName;
           
        }

        private void botonMenuSubir_Click(object sender, EventArgs e)
        {
            panelDescarga.Hide();
            panelDesencriptado.Hide();
            panelCifrado.Hide();
            panelSubir.Show();

        }
    }
}
