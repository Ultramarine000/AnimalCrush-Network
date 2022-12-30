using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;
using UnityEngine.PlayerLoop;

public class UpCharListRequest : BasicRequest
{
    private MainPack pack = null;
    public GamePanel gamePanel;
    public override void Awake()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.UpCharacterList;
        base.Awake();
    }
    private void Update()
    {
        if (pack != null)
        {
            gamePanel.UpdateList(pack);
            gameController.RemovePlayer(pack.Str);
            pack = null;
        }
    }
    public override void OnResponse(MainPack pack)
    {
        //receive mainPack
        this.pack = pack;
    }
}
