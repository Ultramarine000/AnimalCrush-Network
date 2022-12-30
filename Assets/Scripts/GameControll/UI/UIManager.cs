using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;

public class UIManager : BasicManager
{
    public UIManager(GameController gameController) : base(gameController) { }

    private Dictionary<PanelType, BasicPanel> panelDict = new Dictionary<PanelType, BasicPanel>();
    private Dictionary<PanelType, string> panelPath = new Dictionary<PanelType, string>();

    private Stack<BasicPanel> panelStack = new Stack<BasicPanel>();

    private Transform canvasTransform;
    private MessagePanel messagePanel;

    public override void OnInit()
    {
        base.OnInit();
        //Resources.Load("");
        InitPanel();
        canvasTransform = GameObject.Find("Canvas").transform;

        //Default instan
        PushPanel(PanelType.Message);
        PushPanel(PanelType.Start);
        //PushPanel(PanelType.Zero);
    }

    //show UI
    public BasicPanel PushPanel(PanelType panelType)
    {
        if(panelDict.TryGetValue(panelType, out BasicPanel panel))
        {
            if(panelStack.Count > 0)
            {
                BasicPanel topPanel = panelStack.Peek();
                topPanel.OnPause();
            }
            panelStack.Push(panel);
            panel.OnEnter();
            return panel;
        }
        else
        {
            BasicPanel panel1 = SpawnPanel(panelType);
            if(panelStack.Count > 0)
            {
                BasicPanel topPanel = panelStack.Peek();
                topPanel.OnPause();
            }
            panelStack.Push(panel1);
            panel1.OnEnter();
            return panel1;
        }
    }

    //SwitchLogin current UI panel
    public void PopPanel()
    {
        if (panelStack.Count == 0) return;

        BasicPanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        BasicPanel panel = panelStack.Peek();
        panel.OnResuem();
    }
    public BasicPanel PopAndReternNext()
    {
        if (panelStack.Count == 0) return null;

        BasicPanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        BasicPanel panel = panelStack.Peek();
        panel.OnResuem();
        return panel;
    }

    //Instantiate UI
    private BasicPanel SpawnPanel(PanelType panelType)
    {
        if(panelPath.TryGetValue(panelType, out string path))
        {
            GameObject g = GameObject.Instantiate(Resources.Load(path) as GameObject);
            g.transform.SetParent(canvasTransform, false);
            BasicPanel panel = g.GetComponent<BasicPanel>();
            panel.SetUIMsg = this;
            panelDict.Add(panelType, panel);            
            return panel;
        }
        else
        {
            return null;
        }
    }
    //Initiate UI path 初始化
    private void InitPanel()
    {
        string panelpath = "Panel/";
        string[] path = new string[] { "MessagePanel", "StartPanel", "LoginPanel", "SignupPanel", "RoomListPanel", "RoomPanel", "GamePanel", "ResultPanel"};
        panelPath.Add(PanelType.Message, panelpath + path[0]);
        panelPath.Add(PanelType.Start, panelpath + path[1]);
        panelPath.Add(PanelType.Login, panelpath + path[2]);
        panelPath.Add(PanelType.Logon, panelpath + path[3]);
        panelPath.Add(PanelType.RoomList, panelpath + path[4]);
        panelPath.Add(PanelType.Room, panelpath + path[5]);
        panelPath.Add(PanelType.Game, panelpath + path[6]);
        panelPath.Add(PanelType.Gameover, panelpath + path[7]);
    }
    public void SetMessagePanel(MessagePanel message)
    {
        messagePanel = message;
    }
    public void ShowMessage(string str, bool sync = false)
    {
        messagePanel.ShowMessage(str, sync);
    }
}
