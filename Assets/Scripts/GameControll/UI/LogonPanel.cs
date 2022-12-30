using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogonPanel : BasicPanel
{
    public LogonRequest logonRequest;
    public InputField username, password;
    public Button logonBtn, switchBtn;

    private void Start()
    {
        logonBtn.onClick.AddListener(OnLogonClick);
        switchBtn.onClick.AddListener(SwitchLogin);
    }
    private void OnLogonClick()
    {
        //Debug.Log("click");
        if(username.text == "" || password.text == "")
        {
            Debug.Log("Must input Username and Password");
            return;
        }
        logonRequest.SendRequest(username.text, password.text);
    }
    private void SwitchLogin()
    {
        uiManager.PopPanel();
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
                uiManager.ShowMessage("Sign up successfully");
                uiManager.PushPanel(PanelType.Login);
                break;
            case ReturnCode.Fail:
                //Debug.LogWarning("Logon Failed");
                uiManager.ShowMessage("Sign up failed");
                break;
            default:
                Debug.Log("def");
                break;
        }
    }
}
