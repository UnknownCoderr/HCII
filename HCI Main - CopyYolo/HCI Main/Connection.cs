using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_Main
{
    public class ClientC
    {        
        NetworkStream stream;        
        TcpClient tcpClient;
        public float accuracy;
        public string classify;        
        public Boolean isConnected = false;
        public string data;
        public bool connectToSocket(String host, int portNumber)
        {
            try
            {
                tcpClient = new TcpClient(host, portNumber);
                stream = tcpClient.GetStream();
                Console.WriteLine("Connection Made ! with " + host + portNumber);
                isConnected = true;
                return true;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                MessageBox.Show("An error occurred: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool recieveMessage()
        {
            try
            {
                byte[] recieveBuffer = new byte[1024];
                int bytesReceived = stream.Read(recieveBuffer, 0, recieveBuffer.Length);

                data = Encoding.UTF8.GetString(recieveBuffer, 0, bytesReceived);
                string[] points = data.Split(',');
                
                for (int i = 0; i < points.Length; i++)
                {
                    Console.WriteLine(points[i]);
                }
                
                return true;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                Console.WriteLine("Connection failed:" + e);
                return false;
            }
        }

        public bool closeConnection()
        {
            stream.Close();
            tcpClient.Close();
            Console.WriteLine("connection terminated");
            return true;
        }
    }

}
