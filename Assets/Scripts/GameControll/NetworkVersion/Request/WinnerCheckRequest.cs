using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCheckRequest : BasicRequest
{
    private MainPack pack = null;

    public override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.CheckWinner;
        base.Awake();
    }
    public void SendRequest()
    {
        MainPack pack = new MainPack();
        //PlayerPack playerPack = new PlayerPack();
        //playerPack.PlayerAlive = false;
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        pack.Str = "r";
        //pack.Playerpack.Add(playerPack);
        base.SendRequest(pack);
    }

    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
