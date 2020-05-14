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

namespace CopiasSeguras
{
    public partial class Form2 : Form
    {
        private static string passHash2;
        private static System.Timers.Timer timer;
        public static int dateDay;
        public static int dateMonth;
        public static int dateYear;

        public static int dateMinute;

        public Form2(string passw)
        {
            InitializeComponent();

            passHash2 = passw;
            
            //Genera las claves RSA
            Cifrado.RSA.generateRSAKeys();

            //Crea el timer
            SetTimer();

            //Almacena los datos de la fecha actual para los backups
            DateTime date = DateTime.Now;
            dateDay = date.Day;
            dateMonth = date.Month;
            dateYear = date.Year;
            dateMinute = date.Minute;

            Console.ReadLine();
        }

        //Crea el timer
        private static void SetTimer()
        {
            //Crea un timer con intervalo de 1 segundo
            timer = new System.Timers.Timer(1000);
            // Conecta el evento para el timer
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //Decide cuando hay que hacer un backup
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Guarda la fecha actual
            DateTime date = DateTime.Now;
            int dateDayAct = date.Day;
            int dateMonthAct = date.Month;
            int dateYearAct = date.Year;
            int dateMinuteAct = date.Minute;

            //Si la fecha actual ha cambiado respecto la fecha cuando se logeo el usuario, relizara la copia de seguridad
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

        //Realiza las copias de seguridad
        public static void backup()
        {
            //Comprime el archivo con los datos para la copia de seguridad
            String firstPath = @"C:\Backups\Files";
            zip zip = new zip();
            zip.Comprimir(firstPath);
            String path = firstPath + ".zip";

            //Genera el nombre del backup
            string fecha = DateTime.Now.Date.ToString();
            fecha = fecha + " " + DateTime.Now.DayOfWeek + " " + DateTime.Now.Hour + ";" + DateTime.Now.Minute;
            fecha = fecha.Replace('/', '-');
            String[] split = fecha.Split(' ');
            fecha = split[0] + " " + split[2] + " " + split[3];

            //Cambia el nombre al archivo
            String newPath = @"C:\Backups\" + fecha + ".zip";
            File.Move(path, newPath);

            //Encripta el backup
            byte[] ArchivoCifrar = File.ReadAllBytes(newPath);
            byte[] encriptado = Cifrado.AES.AESCrypto("Encriptar", ArchivoCifrar, newPath, passHash2);
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
            //Si el usuario desea encriptar con AES
            if(comboBox1.Text == "AES"){
                if (ArchivoaCifrar.Text != "")
                {
                    //Comprime el archivo seleccionado
                    String path = ArchivoaCifrar.Text;
                    zip zip = new zip();
                    zip.Comprimir(path);

                    //Borra el archivo sin comprimir
                    string pathZip = path;
                    Directory.Delete(pathZip, true);

                    path = path + ".zip";

                    byte[] ArchivoCifrar = File.ReadAllBytes(path);

                    string jsonString;
                    jsonString = JsonSerializer.Serialize(Encoding.UTF8.GetString(ArchivoCifrar));

                    byte[] serilizado = Encoding.UTF8.GetBytes(jsonString);

                    //Encripta el archivo comprimido
                    byte[] encriptado = Cifrado.AES.AESCrypto("Encriptar", ArchivoCifrar, path, passHash2);

                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(encriptado));
                    Console.WriteLine(jsonString);
                }
                else
                {
                    MessageBox.Show("Selecciona una carpeta");
                }
            }
            //Si el usuario desea encriptar con RSA
            else if (comboBox1.Text == "RSA"){
                if (ArchivoaCifrar.Text != "")
                {
                    String path = ArchivoaCifrar.Text;
                    
                    zip zip = new zip();
                    zip.Comprimir(path);

                    string pathZip = path;
                    Directory.Delete(pathZip, true);

                    path = path + ".zip";

                    byte[] ArchivoCifrar = File.ReadAllBytes(path);

                    string jsonString;
                    jsonString = JsonSerializer.Serialize(Encoding.UTF8.GetString(ArchivoCifrar));

                    byte[] serilizado = Encoding.UTF8.GetBytes(jsonString);

                    byte[] encriptado = Cifrado.RSA.RSAEncrypt(ArchivoCifrar, path);


                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(encriptado));
                    Console.WriteLine(jsonString);
                }
                else
                {
                    MessageBox.Show("Selecciona una carpeta");
                }

            }
            else{
                MessageBox.Show("Selecciona un tipo de cifrado");
            }
        }

        private void botonDesencriptar_Click(object sender, EventArgs e)
        {
            //Si el usuario desea desencriptar con AES
            if (comboBox3.Text == "AES"){
                if (ArchivoaDescifrar.Text != ""){
                    String path = ArchivoaDescifrar.Text;

                    byte[] ArchivoDescifrar = File.ReadAllBytes(path);

                    string jsonString;
                    jsonString = JsonSerializer.Serialize(Encoding.UTF8.GetString(ArchivoDescifrar));

                    byte[] serilizado = Encoding.UTF8.GetBytes(jsonString);
                    
                    //Desencripta el fichero comprimido
                    byte[] desencriptado = Cifrado.AES.AESCrypto("Desencriptar", ArchivoDescifrar, path, passHash2);

                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(desencriptado));
                    Console.WriteLine(jsonString);
            
                    //Descomprime el fichero
                    zip zip = new zip();
                    zip.Descomprimir(path);

                    //Borra el archivo encriptado
                    string pathZip = path;
                    File.Delete(pathZip);
                    //System.Diagnostics.Debug.WriteLine(pathZip);
                }
                else
                {
                    MessageBox.Show("Selecciona un archivo");
                }
            }
            //Si el usuario desea desencriptar con AES
            else if (comboBox3.Text == "RSA"){
                if (ArchivoaDescifrar.Text != "")
                {
                    String path = ArchivoaDescifrar.Text;

                    byte[] ArchivoDescifrar = File.ReadAllBytes(path);

                    string jsonString;
                    jsonString = JsonSerializer.Serialize(Encoding.UTF8.GetString(ArchivoDescifrar));

                    byte[] serilizado = Encoding.UTF8.GetBytes(jsonString);

                    byte[] desencriptado = Cifrado.RSA.RSADecrypt(ArchivoDescifrar, path);

                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(desencriptado));
                    Console.WriteLine(jsonString);

                    zip zip = new zip();
                    zip.Descomprimir(path);

                    string pathZip = path;
                    File.Delete(pathZip);
                }
                else
                {
                    MessageBox.Show("Selecciona un archivo");
                }

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
                // y guardarlo en un fichero o algo
               

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

    }
}
