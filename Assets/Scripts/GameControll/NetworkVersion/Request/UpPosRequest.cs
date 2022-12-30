using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPosRequest : BasicRequest
{
    private MainPack pack = null;
    public override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpPos;
        base.Awake();
    }

    public void SendRequest(Vector3 pos, float charRot)
    {
        MainPack mainPack = new MainPack();
        PosPack posPack = new PosPack();
        PlayerPack playerPack = new PlayerPack();
        posPack.PosX = pos.x;
        posPack.PosY = pos.y;
        posPack.PosZ = pos.z;
        posPack.RotY = charRot;
        playerPack.Playername = gameController.UserName;
        playerPack.Pospack = posPack;
        mainPack.Playerpack.Add(playerPack);
        mainPack.RequestCode = requestCode;
        mainPack.ActionCode = actionCode;
        base.SendRequestUDP(mainPack);
    }

    /*private void Update()
    {
        if(pack != null)
        {
            gameController.UpPos(pack);
            pack = null;
        }
    }*/

    public override void OnResponse(MainPack pack)
    {
        //this.pack = pack;
        gameController.UpPos(pack);
        Debug.Log("uping");
    }
}
