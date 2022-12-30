using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NetworkTest;
using Google.Protobuf;

public class Message
{
    private byte[] buffer = new byte[1024];

    private int startIndex;//buffer存到第几位

    public byte[] Buffer
    { get { return buffer; } }
    public int StartIndex
    { get { return startIndex; } }
    public int RemainSize//buff剩余空间
    {
        get { return buffer.Length - startIndex; }
    }

    public void ReadBuffer(int len, Action<MainPack> HandleResponse)//Callback Func
    {
        startIndex += len;        
        //开始循环解析
        while (true)
        {
            if (startIndex <= 4)//分包不完整
            {
                return;
            }
            int count = BitConverter.ToInt32(buffer, 0);

            if (startIndex >= (count + 4))
            {
                //解析消息返回Mainpack
                MainPack pack = (MainPack)MainPack.Descriptor.Parser.ParseFrom(buffer, 4, count);
                HandleResponse(pack);//Call Client's HandleRequest(), Client call server's HandleRequest()
                                     //从count+4的位置开始复制startindex-count-4个长度，复制到buffer数组从0开始的位置
                Array.Copy(buffer, count + 4, buffer, 0, startIndex - count - 4);
                startIndex -= (count + 4);
            }
            else
            {
                break;
            }
        }

    }
    public static byte[] PackData(MainPack pack)
    {
        //pack内容
        byte[] packData = pack.ToByteArray();
        //pack索引（占位）
        byte[] packHead = BitConverter.GetBytes(packData.Length);
        return packHead.Concat(packData).ToArray();
    }
    public static Byte[] PackDataUDP(MainPack pack)
    {
        return pack.ToByteArray();
    }
}
