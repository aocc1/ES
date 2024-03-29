﻿using System;
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
        private static System.Timers.Timer timer;
        public static int dateDay;
        public static int dateMonth;
        public static int dateYear;

        public static int dateMinute;
        public static Boolean servidorLibre = true;
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
            //Crea un timer con intervalo de 10 minutos
            timer = new System.Timers.Timer(600000);
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
                servidorLibre = false;
                backup("Y");
                servidorLibre = true;
                dateYear = dateYearAct;
                
            }
            else if (dateMonthAct != dateMonth)
            {
                servidorLibre = false;
                backup("M");
                servidorLibre = true;
                dateMonth = dateMonthAct;
            }
            else if (dateDayAct != dateDay)
            {
                servidorLibre = false;
                backup("D");
                servidorLibre = true;
                dateDay = dateDayAct;
            }
            else if (dateMinuteAct != dateMinute)
            {
                servidorLibre = false;
                backup("S");
                servidorLibre = true;
                dateMinute = dateMinuteAct;
            }
        }

        //Realiza las copias de seguridad
        public static void backup(string typeBackup)
        {
            //Comprime el archivo con los datos para la copia de seguridad
            String firstPath = @"C:\Backups\Files";
            zip zip = new zip();
            zip.Comprimir(firstPath);
            String path = firstPath + ".zip";

            //Genera el nombre del backup
            string fecha = DateTime.Now.Date.ToString();
            fecha = fecha + " " + DateTime.Now.DayOfWeek + " " + DateTime.Now.Hour + ";" + DateTime.Now.Minute.ToString("00.##");
            fecha = fecha.Replace('/', '-');
            String[] split = fecha.Split(' ');
            fecha = typeBackup + "_" + split[0] + "_" + split[2] + "_" + split[3];

            //Cambia el nombre al archivo
            String newPath = @"C:\Backups\" + fecha + ".zip";
            File.Move(path, newPath);

            //Encripta el backup
            byte[] ArchivoCifrar = File.ReadAllBytes(newPath);
            byte[] encriptado = Cifrado.AES.AESCrypto("Encriptar", ArchivoCifrar, newPath, passHash2);

            //Se sube el backup al servidor
            SslTcpClient.backup(fecha, encriptado);
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
                    String path = ArchivoaCifrar.Text;

                    //Comprime el archivo seleccionado
                    zip zip = new zip();
                    zip.Comprimir(path);

                    //Borra el archivo sin comprimir
                    string pathZip = path;
                    Directory.Delete(pathZip, true);

                    path = path + ".zip";

                    //Cifra el archivo compimido
                    byte[] ArchivoCifrar = File.ReadAllBytes(path);                
                    byte[] encriptado = Cifrado.AES.AESCrypto("Encriptar", ArchivoCifrar, path, passHash2);
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
                    byte[] encriptado = Cifrado.RSA.RSAEncrypt(ArchivoCifrar, path);
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
                if (ArchivoaDescifrar.Text != "")
                {
                    String path = ArchivoaDescifrar.Text;

                    //Descifra el archivo comprimido
                    byte[] ArchivoDescifrar = File.ReadAllBytes(path);
                    byte[] desencriptado = Cifrado.AES.AESCrypto("Desencriptar", ArchivoDescifrar, path, passHash2);

                    //Descomprime el fichero
                    zip zip = new zip();
                    zip.Descomprimir(path);

                    //Borra el archivo encriptado
                    string pathZip = path;
                    File.Delete(pathZip);
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
                    byte[] desencriptado = Cifrado.RSA.RSADecrypt(ArchivoDescifrar, path);

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
            if (servidorLibre) {
                panelCifrado.Hide();
                panelDesencriptado.Hide();
                panelSubir.Hide();
                panelDescarga.Show();
                comboBox2.Items.Clear();
                //peticion de datos
                servidorLibre = false;
                String[] listaDatos = SslTcpClient.consultData();
                servidorLibre = true;
                if (listaDatos != null)
                {
                    foreach (string nombre in listaDatos)
                    {
                        comboBox2.Items.Add(nombre);
                    }
                }

            }
            else
            {
                MessageBox.Show("Servidor Ocupado , espera a que termine de guardar los cambios");
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
            if (servidorLibre)
            {
                if (comboBox2.Text != "")
                {
                    servidorLibre = false;
                    byte[] datos = SslTcpClient.download(comboBox2.Text);
                    servidorLibre = true;
                    File.WriteAllBytes(ArchivoDescargar.Text + "\\" + comboBox2.Text + ".zip", datos);
                    MessageBox.Show("Descargado correctamente");
                }
                else
                {
                    MessageBox.Show("Selecciona un archivo de la lista");
                }
            }
            else
            {
                MessageBox.Show("Servidor ocupado , espera a que se guarden los cambios");
            }

        }

        private void botonSubir_Click(object sender, EventArgs e)
        {
            if (servidorLibre)
            {
                if (ArchivoaSubir.Text != "")
                {
                    if (nombreFicheroAsubir.Text != "")
                    {
                        byte[] ArchivoSubir = File.ReadAllBytes(ArchivoaSubir.Text);
                        servidorLibre = false;
                        SslTcpClient.save(nombreFicheroAsubir.Text, ArchivoSubir);
                       
                        servidorLibre = true;
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
            else
            {
                MessageBox.Show("Servidor ocupado , espera a que se guarden los cambios");
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
