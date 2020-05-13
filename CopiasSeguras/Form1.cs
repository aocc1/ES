using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using cliente.tcp;

namespace CopiasSeguras
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //registro

            panelInicio.Hide();
            panelRegistro.Show();

        }

        private void registrar_Click(object sender, EventArgs e)
        {
            
            if (Equals(passReg1.Text, passReg2.Text))
            {
                //Hashea la contraseña del usuario
                string passHash = getHash(passReg1.Text);
                //La primera mitad sera la contraseña de usuario
                string passHash1 = passHash.Substring(0,passHash.Length/2);

                //registrarse
                SslTcpClient.Start();
                if(SslTcpClient.register(nombreRegistro.Text, passHash1))
                {
                    
                    SslTcpClient.conecctionClose();
                    panelRegistro.Hide();
                    panelInicio.Show();
                }
                else
                {
                    SslTcpClient.conecctionClose();
                }

                

            }
            else
            {
                MessageBox.Show("La contraseña no coincide");
            }
            
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            this.Hide();

            string passHash = getHash(passInicio.Text);
            string passHash1 = passHash.Substring(0, passHash.Length / 2);
            //La segunda mitad de la contraseña hasheada sera para cifrar archivos
            string passHash2 = passHash.Replace(passHash1, "");

            String pass = passHash1;
            String user = usuarioInicio.Text;
            SslTcpClient.Start();
            

            if(SslTcpClient.authenticate(usuarioInicio.Text, passHash1))
            {
                Form2 f2 = new Form2(passHash2);
                f2.ShowDialog();


                this.Close();
            }
            else
            {
                SslTcpClient.conecctionClose();
            }

            //Console.WriteLine(System.Text.Encoding.UTF8.GetString(haseo));



        }

        //Hashea una contraseña
        private string getHash(string pas)
        {
            //El algoritmo es SHA256
            HashAlgorithm algorithm = SHA256.Create();
            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(pas));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
