using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasicPanel
{
    public LoginRequest loginRequest;
    public InputField username, password;
    public Button loginBtn, switchBtn;

    private void Start()
    {
        loginBtn.onClick.AddListener(OnLoginClick);
        switchBtn.onClick.AddListener(SwitchLogon);
    }
    private void OnLoginClick()
    {
        //Debug.Log("click");
        if (username.text == "" || password.text == "")
        {
            Debug.Log("Must input Username and Password");
            return;
        }
        loginRequest.SendRequest(username.text, password.text);
    }
    private void SwitchLogon()
    {
        uiManager.PushPanel(PanelType.Logon);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Enter();
    }
    public override void OnPause()
    {
        base.OnPause();
        Exit();
    }
    public override void OnResuem()
    {
        base.OnResuem();
        Enter();
    }
    public override void OnExit()
    {
        base.OnExit();
        Exit();
    }
    private void Enter()
    {
        gameObject.SetActive(true);
    }
    private void Exit()
    {
        gameObject.SetActive(false);
    }
    public void OnResponse(MainPack pack)
    {
        switch (pack.ReturnCode)
        {
            case ReturnCode.Succeed:
                //Debug.Log("Logon Succeed");
                uiManager.ShowMessage("Log in successfully");
                gameController.UserName = username.text;
                uiManager.PushPanel(PanelType.RoomList);
                break;
            case ReturnCode.Fail:
                //Debug.LogWarning("Logon Failed");
                uiManager.ShowMessage("Log in failed");
                break;
            default:
                Debug.Log("login def");
                break;
        }
    }
}
