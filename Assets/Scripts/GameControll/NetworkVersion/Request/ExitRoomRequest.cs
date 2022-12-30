using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;

public class ExitRoomRequest : BasicRequest
{
    private bool isExit = false;
    public RoomPanel roomPanel;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.Exit;
        base.Awake();
    }

    public void SendRequest()
    {
        MainPack pack = new MainPack();
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        pack.Str = "r";
        base.SendRequest(pack);
    }

    private void Update()
    {
        if(this.isExit)
        {
            roomPanel.ExitRoomResponse();
            isExit = false;
        }
    }

    public override void OnResponse(MainPack pack)
    {
        isExit = true;
    }
}
