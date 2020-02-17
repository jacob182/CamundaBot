using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace Camunda_Bot
{

    class UDPHandler
    {
        private int receivePort, sendPort;
        private string serverIP;
        private IPEndPoint sendEndPoint, receiveEndPoint;

        public UDPHandler(string serverIP, int receivePort, int sendPort)
        {
            this.serverIP = serverIP;
            this.receivePort = receivePort;
            this.sendPort = sendPort;
            this.sendEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), this.sendPort);
            this.receiveEndPoint = new IPEndPoint(IPAddress.Parse(this.serverIP), this.receivePort);
            this.readerUdpClient();
            this.senderUdpClient();
        }
        void readerUdpClient()
        {
            new Thread(() => {
                UdpClient readerClient = new UdpClient(receivePort);
                Console.WriteLine("Awaiting data from server...");
                var remoteEP = new IPEndPoint(IPAddress.Any, 0);
                byte[] bytesReceived = readerClient.Receive(ref remoteEP);
                Console.WriteLine($"Received {bytesReceived.Length} bytes from {remoteEP}");
            }).Start();
        }

        void senderUdpClient()
        {
            UdpClient senderClient = new UdpClient();
            senderClient.Connect(this.sendEndPoint);
            string sendString = "1;2;3";
            byte[] bytes = toBytes(sendString);
            Thread t = new Thread(() => {
                while (true)
                {
                    senderClient.Send(bytes, bytes.Length);
                    Thread.Sleep(1000);
                }
            });
            t.Start();
        }

        public byte[] toBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public string fromBytes(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string serverIP = "46.101.102.243";
            int sendPort = 41234;
            int receivePort = 3000;
            UDPHandler handler = new UDPHandler(serverIP, receivePort, sendPort);
        }
    }
}
