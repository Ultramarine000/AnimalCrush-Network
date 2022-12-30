using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;

public class StartGameRequest : BasicRequest
{
    private MainPack pack = null;
    public RoomPanel roomPanel;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.StartGame;
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
        if(pack != null)
        {
            roomPanel.StartGameResponse(pack);
            pack = null;
        }
    }

    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
