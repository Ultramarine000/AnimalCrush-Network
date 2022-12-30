using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using NetworkTest;
using System.Threading;
using static UnityEngine.UI.CanvasScaler;
using System.Net;

public class ClientManager : BasicManager
{
    private Socket socket;
    private Message message;
    private Thread aucThread;
    //public static string commingip;
    public string ip;// = "10.167.203.75";
    //public string ip = "10.167.203.75";//parker
    //private const string ip = "172.16.0.20";//eu
    //private const string ip = "192.168.200.50";//hot

    public ClientManager(GameController gameController, string ip) : base(gameController) { this.ip = ip; }

    public override void OnInit()
    {
        base.OnInit();        
        message = new Message();
        //socket初始化
        InitSocket();
        InitUDP();
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        message = null;
        CloseSocket();
        if(aucThread != null)
        {
            aucThread.Abort();
            aucThread = null;
        }
    }
    private void InitSocket()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            //socket.Connect("127.0.0.1", 6666);
            socket.Connect(ip, 6666);
            //连接成功
            StartReceive();
            gameController.ShowMessage("Connected successfully!!!!!!");
        }
        catch(Exception e)
        {
            //连接出错
            Debug.LogWarning(e);
            gameController.ShowMessage("Connected failed!!!!!!");
        }
    }
    private void CloseSocket()
    {
        if(socket.Connected && socket != null)
        {
            socket.Close();
        }
    }

    //Sent and Receive
    private void StartReceive()
    {
        socket.BeginReceive(message.Buffer,message.StartIndex,message.RemainSize,SocketFlags.None, ReceiveCallback, null);
    }
    private void ReceiveCallback(IAsyncResult iar)
    {
        try
        {
            if(socket == null || socket.Connected == false) return;
            int len = socket.EndReceive(iar);
            if(len== 0)
            {
                CloseSocket();
                return;
            }
            //receive
            message.ReadBuffer(len, HandleResponse);//异步处理
            StartReceive();
        }
        catch(Exception E)
        {
            Debug.LogWarning(E.Message);
        }
    }
    //异步处理
    private void HandleResponse(MainPack pack)
    {
        gameController.HandleResponse(pack);
        Debug.Log("clientmanager handle, receive AC: " + pack.ActionCode.ToString());
    }
    public void Send(MainPack pack)
    {
        socket.Send(Message.PackData(pack));
        Debug.Log("ClientManager Send AC: " + pack.ActionCode.ToString());
    }





    ///UDP Protocol////////////////////

    private Socket udpClient;
    private IPEndPoint ipEndPoint;
    private EndPoint EPoint;
    private Byte[] buffer = new byte[1024];

    private void InitUDP()
    {
        udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 6667);
        EPoint = ipEndPoint;
        try
        {
            udpClient.Connect(EPoint);
        }
        catch
        {
            Debug.LogWarning("UDP connected failed");
            return;
        }
        Loom.RunAsync
        ( ()=>
            {
                aucThread = new Thread(ReceiveMsg);
                aucThread.Start();
            }
        );

        //Action action = () =>
        //{

        //};
        
    }

    private void ReceiveMsg()
    {
        Debug.Log("UDP is receiving");
        while(true)
        {
            int len = udpClient.ReceiveFrom(buffer, ref EPoint);
            MainPack pack = (MainPack)MainPack.Descriptor.Parser.ParseFrom(buffer, 0, len);
            //Debug.Log("Receiving: " + pack.ActionCode.ToString() + pack.User);
            //HandleResponse(pack);

            //Main Thread
            Loom.QueueOnMainThread ( (param)=>
            {
                HandleResponse(pack);
            }, null);
        }
    }

    public void SendTo(MainPack pack)
    {
        Byte[] sendBuff = Message.PackDataUDP(pack);
        udpClient.Send(sendBuff, sendBuff.Length, SocketFlags.None);
    }
}

  
