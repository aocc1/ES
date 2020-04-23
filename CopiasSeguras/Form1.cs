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
               

                //registrarse
                SslTcpClient.Start(nombreRegistro.Text, passReg1.Text);
                SslTcpClient.register(nombreRegistro.Text, passReg1.Text);

                panelRegistro.Hide();
                panelInicio.Show();

            }
            else
            {
                MessageBox.Show("La contraseña no coincide");
            }
            
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            this.Hide();

            String pass = passInicio.Text;

            SHA256 sha256 = SHA256.Create();

            byte[] haseo = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));

            //Console.WriteLine(System.Text.Encoding.UTF8.GetString(haseo));

            Form2 f2 = new Form2();
            f2.ShowDialog();


            this.Close();

        }
    }
}
