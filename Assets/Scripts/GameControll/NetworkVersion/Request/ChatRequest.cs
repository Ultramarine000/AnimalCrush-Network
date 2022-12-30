using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;

public class ChatRequest : BasicRequest
{
    string chatStr = null;
    public RoomPanel roomPanel;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.Chat;
        base.Awake();
    }
    public void SendRequest(string str)
    {
        MainPack pack = new MainPack();
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        pack.Str = str;

        base.SendRequest(pack);
    }

    private void Update()
    {
        if(chatStr != null)
        {
            roomPanel.ChatResopnse(chatStr);

            chatStr = null;
        }
    }
    public override void OnResponse(MainPack pack)
    {
        chatStr = pack.Str;
    }
}
