using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;

public class JoinRoomRequest : BasicRequest
{
    private MainPack pack = null;
    public RoomListPanel roomListPanel;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.JoinRoom;
        base.Awake();
    }

    public void SendRequest(string roomname)
    {
        MainPack pack = new MainPack();
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        pack.Str = roomname;
        base.SendRequest(pack);
    }

    private void Update()
    {
        if (pack != null)
        {
            roomListPanel.JoinRoomResponse(pack);
            pack = null;
        }
    }
    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
