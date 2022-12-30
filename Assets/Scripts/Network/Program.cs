using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SoccketMultiplayerGameServer
{
    class Program
    {
        private static Socket socket;
        private static byte[] buffer = new byte[1024];

        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 8888));
            //同时多个请求连接，最大处理x=0个
            socket.Listen(0);
            StartAccept();
            Console.Read();
        }

        static void StartAccept()
        {
            socket.BeginAccept(AcceptCallback, null);
        }

        static void StartReceive(Socket client)
        {
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallBack, client);
        }
        static void ReceiveCallBack(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int len = client.EndReceive(iar);
            if (len == 0)
            {
                return;
            }
            string str = Encoding.UTF8.GetString(buffer, 0, len);
            Console.WriteLine(str);

            StartReceive(client);
        }
        static void AcceptCallback(IAsyncResult iar)
        {
            Socket client = socket.EndAccept(iar);
            StartReceive(client);
            StartAccept();
        }
    }
}
