using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace cliente.tcp
{

    public class SslTcpClient

    {
        public static String user;
        public static String pass;
        public static TcpClient client;
        public static SslStream sslStream;



        private static Hashtable certificateErrors = new Hashtable();



        // The following method is invoked by the RemoteCertificateValidationDelegate.
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return true;
        }
        public static void RunClient(string machineName, string serverName)
        {
            // Create a TCP/IP client socket.
            // machineName is the host running the server application.
            client = new TcpClient(machineName, 8080);
            Console.WriteLine("Client connected.");
            // Create an SSL stream that will close the client's stream.
            sslStream = new SslStream(
                client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
                );
            // The server name must match the name on the server certificate.
            try
            {
                sslStream.AuthenticateAsClient(serverName);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                client.Close();
                return;
            }

            /*
            // Encode a test message into a byte array.
            // Signal the end of the message using the "<EOF>".
            byte[] messsage = Encoding.UTF8.GetBytes(indicative+" "+user + " "+pass+".<EOF>");
            //byte[] messsage = Encoding.UTF8.GetBytes("Hello from the client.<EOF>");
            // Send hello message to the server. 
            sslStream.Write(messsage);
            sslStream.Flush();
            // Read message from the server.
            string serverMessage = ReadMessage(sslStream);
            Console.WriteLine("Server says: {0}", serverMessage);
            // Close the client connection.
            client.Close();
            Console.WriteLine("Client closed.");
            */
        }
        static string ReadMessage(SslStream sslStream)
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.ASCII.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                // Check for EOF.
                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {
                    break;
                }
            } while (bytes != 0);

            return messageData.ToString();
        }
        public static void conecctionClose() {
            byte[] messsage = Encoding.ASCII.GetBytes("Cerrar.<EOF>");
            sslStream.Write(messsage);
            sslStream.Flush();
            client.Close();
        }
        public static Boolean authenticate(String u, String p)
        {
            byte[] messsage = Encoding.ASCII.GetBytes("A" + " " + u + " " + p + ".<EOF>");

            sslStream.Write(messsage);
            sslStream.Flush();
            string serverMessage = ReadMessage(sslStream);

            if (serverMessage == "Bienvenido " + u + ".<EOF>")
            {
                user = u;
                pass = p;
                return true;
            }
            else
            {
                MessageBox.Show(serverMessage);
                return false;
            }

        }

        public static Boolean register(String u, String p)
        {
            byte[] messsage = Encoding.ASCII.GetBytes("R" + " " + u + " " + p + ".<EOF>");
            
            sslStream.Write(messsage);
            sslStream.Flush();
            string serverMessage = ReadMessage(sslStream);

            if (serverMessage == "Registrado correctamente.<EOF>")
            {
                return true;
            }
            else
            {
                MessageBox.Show(serverMessage);
                return false;
            }

        }
        public static byte[] download(String nombreDatos)
        {
            byte[] messsage = Encoding.ASCII.GetBytes("D" + " " + user + " " + nombreDatos + ".<EOF>");

            sslStream.Write(messsage);
            sslStream.Flush();
            string serverMessage = ReadMessage(sslStream);
            serverMessage = serverMessage.Replace(".<EOF>", "");

            return Convert.FromBase64String(serverMessage);



        }

        public static String[] consultData()
        {
            byte[] messsage = Encoding.ASCII.GetBytes("C" + " " + user + ".<EOF>");


            sslStream.Write(messsage);
            sslStream.Flush();
            string serverMessage = ReadMessage(sslStream);
            String[] dataCount = serverMessage.Split('.'); 
            Int32 count = Int32.Parse(dataCount[0]);

            String[] strlist = null;
            if (count != 0)
            {
                serverMessage = ReadMessage(sslStream);
                String[] separator = { " " };
                strlist = serverMessage.Split(separator, count, StringSplitOptions.RemoveEmptyEntries);

                for (int i=0; i<strlist.Length;i++)
                {
                    strlist[i] = strlist[i].Replace(".<EOF>","") ;
                }

            }
           
            return strlist;
        }

            public static Boolean save(String nombreDatos , byte[] datos)
        {
            byte[] chunk = new byte[67108864];
            double n = Math.Ceiling((double)datos.Length / chunk.Length);
            
            Debug.WriteLine(n);
            int numBloques = Convert.ToInt32(n);
            
            byte[] messsage = Encoding.ASCII.GetBytes("G" + " " + user + " " + nombreDatos + " " + numBloques + ".<EOF>");
            sslStream.Write(messsage);
            sslStream.Flush();

            /*

            int start = 0;
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Arrays.copyOfRange(datos, start, start + chunksize);
                start += chunksize;
            }
            //
            /*int numBloques = datos. Length;
            byte[] messsage = Encoding.ASCII.GetBytes("G" + " " + user + " " + nombreDatos + " " + numBloques);

            for (int i=0; i<numBloques; i++)
            {
                String datosString = Convert.ToBase64String(datos);

              messsage = Encoding.ASCII.GetBytes("G" + " " + user + " " + nombreDatos + " " + datosString + ".<EOF>");

                sslStream.Write(messsage);
                sslStream.Flush();
            }
            
            */
            string serverMessage = ReadMessage(sslStream);
            if (serverMessage == "Operacion exitosa.<EOF>")
            {
                return true;
            }
            else
            {
                MessageBox.Show(serverMessage);
                return false;
            }
        }
        public static int Start()
        {
            //-A nombre_user contraseña- para autenticar
            //-R nombre_user contraseña- para registrar
            //D nombre_user datos , descarga
            //G nombre_user datos para guardar datos , de momento uno por user
        
        

            string serverCertificateName = null;
            string machineName = null;
           // if (args == null ||args.Length <1 )
            //{
               // DisplayUsage();
            //}
            // User can specify the machine name and server name.
            // Server name must match the name on the server's certificate. 
            machineName = "localhost";
            serverCertificateName = machineName;
            /*
            machineName = args[0];
            if (args.Length <2 )
            {
                serverCertificateName = machineName;
            }
            else 
            {
                serverCertificateName = args[1];
            }
            */
            SslTcpClient.RunClient (machineName, serverCertificateName);
            return 0;
        }
    }
}