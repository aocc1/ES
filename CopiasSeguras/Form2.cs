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
using System.Timers;
using cliente.tcp;
using Microsoft.VisualBasic.FileIO;

namespace CopiasSeguras
{
    public partial class Form2 : Form
    {
        private static string passHash2;
        private static System.Timers.Timer aTimer;
        public static int dateDay;
        public static int dateMonth;
        public static int dateYear;

        public static int dateMinute;

        public Form2(string passw)
        {
            InitializeComponent();

            passHash2 = passw;

            SetTimer();

            DateTime date = DateTime.Now;
            dateDay = date.Day;
            dateMonth = date.Month;
            dateYear = date.Year;

            dateMinute = date.Minute;

            Console.ReadLine();
            //aTimer.Stop();
            //aTimer.Dispose();
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DateTime date = DateTime.Now;
            int dateDayAct = date.Day;
            int dateMonthAct = date.Month;
            int dateYearAct = date.Year;

            int dateMinuteAct = date.Minute;
            
            if (dateYearAct != dateYear)
            {
                backup();
                dateYear = dateYearAct;
            }
            else if (dateMonthAct != dateMonth)
            {
                backup();
                dateMonth = dateMonthAct;
            }
            else if (dateDayAct != dateDay)
            {
                backup();
                dateDay = dateDayAct;
            }
            else if (dateMinuteAct != dateMinute)
            {
                backup();
                dateMinute = dateMinuteAct;
            }
            
        }

        public static void backup()
        {
            String firstPath = @"C:\Backups\Files";
            zip zip = new zip();
            zip.Comprimir(firstPath);
            String path = firstPath + ".zip";

            string fecha = DateTime.Now.Date.ToString();
            fecha = fecha + " " + DateTime.Now.DayOfWeek + " " + DateTime.Now.Hour + ";" + DateTime.Now.Minute;
            fecha = fecha.Replace('/', '-');
            String[] split = fecha.Split(' ');
            fecha = split[0] + " " + split[2] + " " + split[3];

            String newPath = @"C:\Backups\" + fecha + ".zip";
            File.Move(path, newPath);

            byte[] ArchivoCifrar = File.ReadAllBytes(newPath);
            AES cifrador = new AES();
            byte[] encriptado = AES.AESCrypto("Encriptar", ArchivoCifrar, newPath, passHash2);
        }

        private void SlecArchivoButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //esto es para carpetas
            //OpenFileDialog ofd = new OpenFileDialog(); //Para archivos
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ArchivoaCifrar.Text = fbd.SelectedPath;



        }

        private void SelecDescButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); 
           
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ArchivoDescargar.Text = fbd.SelectedPath;

        }

        private void botonEncriptar_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "AES"){
                if (ArchivoaCifrar.Text != ""){
                    String path = ArchivoaCifrar.Text;
                    zip zip = new zip();
                    zip.Comprimir(path);

                    string pathZip = path;
                    System.Diagnostics.Debug.WriteLine(pathZip);
                    Directory.Delete(pathZip, true);

                    path = path + ".zip";

                    byte[] ArchivoCifrar = File.ReadAllBytes(path);

                    AES cifrador = new AES();
                 
                    byte[] encriptado = AES.AESCrypto("Encriptar", ArchivoCifrar, path, passHash2);

                    
                }
                else
                {
                    MessageBox.Show("Selecciona una carpeta");
                }
            }
            else if(comboBox1.Text == "RSA"){

            }
            else{
                MessageBox.Show("Selecciona un tipo de cifrado");
            }
        }

        private void botonDesencriptar_Click(object sender, EventArgs e)
        {
            if(comboBox3.Text == "AES"){
                if (ArchivoaDescifrar.Text != ""){
                    String path = ArchivoaDescifrar.Text;

                    byte[] ArchivoDescifrar = File.ReadAllBytes(path);

                    AES cifrador = new AES();

               
                    byte[] desencriptado = AES.AESCrypto("Desencriptar", ArchivoDescifrar, path, passHash2);

                    
            
                    zip zip = new zip();
                    zip.Descomprimir(path);

                    string pathZip = path;
                    //System.Diagnostics.Debug.WriteLine(pathZip);
                    File.Delete(pathZip);
                }
                else
                {
                    MessageBox.Show("Selecciona un archivo");
                }
            }
            else if(comboBox3.Text == "RSA"){

            }
            else{
                MessageBox.Show("Selecciona un tipo de cifrado");
            }
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

            //peticion de datos
            String[] listaDatos = SslTcpClient.consultData();
            foreach (string nombre in listaDatos)
            {
                comboBox2.Items.Add(nombre);
            }

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

        private void botonDescargar_Click(object sender, EventArgs e)
        {
            
            
            if (comboBox2.Text!="")
            {
                byte[] datos  = SslTcpClient.download(comboBox2.Text);
                File.WriteAllBytes(ArchivoDescargar.Text + "\\" + comboBox2.Text + ".zip", datos);



            }
            else
            {
                MessageBox.Show("Selecciona un nombre de la lista");
            }

        }

        private void botonSubir_Click(object sender, EventArgs e)
        {
            if (ArchivoaSubir.Text != "")
            {
                if (nombreFicheroAsubir.Text != "")
                {
                    byte[] ArchivoSubir = File.ReadAllBytes(ArchivoaSubir.Text);
                    SslTcpClient.save(nombreFicheroAsubir.Text, ArchivoSubir);
                }
                else
                {
                    MessageBox.Show("Introduce un nombre");
                }

                
            }
            else
            {
                MessageBox.Show("Selecciona un fichero");
            }
        }

        private void SelecSubButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //Para archivos
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                ArchivoaSubir.Text = ofd.FileName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
