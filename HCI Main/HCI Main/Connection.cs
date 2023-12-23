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
        public int ct = 0;

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
                if (ct == 0)
                {
                    byte[] recieveBuffer = new byte[1024];
                    int bytesReceived = stream.Read(recieveBuffer, 0, recieveBuffer.Length);
                    string data = Encoding.UTF8.GetString(recieveBuffer, 0, bytesReceived);
                    string[] points = data.Split('(');
                    string[] second = points[1].Split(',');
                    classify = second[0];
                    string[] ok1 = second[1].Split(')');
                    accuracy = float.Parse(ok1[0]);
                    string[] ok = data.Split(',');
                }

                if (ct == 1)
                {
                    byte[] recieveBuffer = new byte[1024];
                    int bytesReceived = stream.Read(recieveBuffer, 0, recieveBuffer.Length);
                    string data = Encoding.UTF8.GetString(recieveBuffer, 0, bytesReceived);
                    Console.WriteLine(data);
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
