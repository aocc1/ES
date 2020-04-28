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
                SslTcpClient.Start();
                if(SslTcpClient.register(nombreRegistro.Text, passReg1.Text))
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

            String pass = passInicio.Text;
            String user = usuarioInicio.Text;
            SslTcpClient.Start();
            

            if(SslTcpClient.authenticate(usuarioInicio.Text, pass))
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();


                this.Close();
            }
            else
            {
                SslTcpClient.conecctionClose();
            }

            //Console.WriteLine(System.Text.Encoding.UTF8.GetString(haseo));



        }
    }
}
