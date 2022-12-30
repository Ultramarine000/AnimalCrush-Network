using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;

public class CreateRoomRequest : BasicRequest
{
    public RoomListPanel roomListPanel;
    private MainPack pack = null;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.CreateRoom;
        base.Awake();
    }
    private void Update()
    {
        if(pack != null)
        {
            roomListPanel.CreateRoomResponse(pack);
            pack = null;
        }
    }
    public void SendRequest(string roomname, int maxnum)
    {
        MainPack pack = new MainPack();
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        RoomPack room = new RoomPack();
        room.Roomname = roomname;
        room.Maxnum = maxnum;
        pack.Roompack.Add(room);
        base.SendRequest(pack);
    }
    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
