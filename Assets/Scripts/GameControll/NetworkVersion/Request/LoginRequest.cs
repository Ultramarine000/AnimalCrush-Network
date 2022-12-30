using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NetworkTest;

public class LoginRequest : BasicRequest
{
    public LoginPanel loginPanel;
    private MainPack pack = null;
    public override void Awake()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        base.Awake();
    }
    private void Update()
    {
        if (pack != null)
        {
            loginPanel.OnResponse(pack);
            pack = null;
        }
    }
    public override void OnResponse(MainPack pack)
    {
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
