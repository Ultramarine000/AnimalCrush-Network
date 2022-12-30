using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRoomRequest : BasicRequest
{
    public RoomListPanel roomListPanel;
    private MainPack pack = null;

    //only change ActionCode than CreateRoomRequest
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.FindRoom;
        base.Awake();
    }

    private void Update()
    {
        if (pack != null)
        {
            roomListPanel.FindRoomResponse(pack);
            pack = null;
        }
    }
    public void SendRequest()
    {
        MainPack pack = new MainPack();
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        pack.Str = "r";
        base.SendRequest(pack);
        //Debug.Log("send FRR");
    }
    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
        //Debug.LogWarning(pack.ActionCode.ToString());
    }
}
