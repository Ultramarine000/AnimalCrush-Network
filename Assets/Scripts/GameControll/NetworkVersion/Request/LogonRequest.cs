using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;
using UnityEngine.Rendering;
using System;

public class LogonRequest : BasicRequest
{
    public LogonPanel logonPanel;
    private MainPack pack = null;
    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Logon;
        base.Awake();
    }
    private void Update()
    {
        if(pack != null)
        {
            logonPanel.OnResponse(pack);
            pack = null;
        }
    }
    public override void OnResponse(MainPack pack)
    {
        //logonPanel.OnResponse(pack);
        this.pack = pack;
    }
    public void SendRequest(String username, String password)
    {
        MainPack pack = new MainPack();
        pack.RequestCode = requestCode;
        pack.ActionCode = actionCode;
        LoginPack loginPack = new LoginPack();
        loginPack.Username = username;
        loginPack.Password = password;
        pack.Loginpack = loginPack;
        base.SendRequest(pack);
    }
}
