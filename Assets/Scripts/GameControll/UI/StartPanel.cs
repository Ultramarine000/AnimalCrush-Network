using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasicPanel
{
    public Button startBtn;
    public void Start()
    {
        startBtn.onClick.AddListener(StartButtonClick);
    }
    private void StartButtonClick()
    {
        uiManager.PushPanel(PanelType.Login);
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
}
