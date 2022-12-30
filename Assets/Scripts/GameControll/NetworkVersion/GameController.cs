using NetworkTest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private ClientManager clientManager;
    private RequestManager requestManager;
    private UIManager uiManager;
    private PlayerManager playerManager;
    private static GameController gameController;
    public static string serverIPStr;
    //public bool haveIP = true;

    public string UserName
    {
        get;set;
    }
    public static GameController Controller
    {
        
        get
        {
            if(gameController == null)
            {
                gameController = GameObject.Find("GameController").GetComponent<GameController>();
            }                
            return gameController;
        } 
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        //InitManager();

        uiManager = new UIManager(this);

        serverIPStr = Resources.Load<IPSO>("DataIP").IP;
        clientManager = new ClientManager(this, serverIPStr);
        //clientManager.ip = serverIPStr;
        requestManager = new RequestManager(this);
        playerManager = new PlayerManager(this);


        uiManager.OnInit();
        clientManager.OnInit();
        requestManager.OnInit();
        playerManager.OnInit();
    }
    private void OnDestroy()
    {
        uiManager.OnDestroy();
        clientManager.OnDestroy();
        requestManager.OnDestroy();
        playerManager.OnDestroy();
    }

    public void Send(MainPack pack)
    {
        clientManager.Send(pack);
    }
    public void SendTo(MainPack pack)
    {
        pack.User = UserName;
        clientManager.SendTo(pack);
    }

    public void HandleResponse(MainPack pack)
    {
        //handle
        requestManager.HandleResponse(pack);
        Debug.Log("GC handle AC: " + pack.ActionCode.ToString());
    }
    public void AddRequest(BasicRequest request)
    {
        requestManager.AddRequest(request);
    }
    public void RemoveRequest(ActionCode actionCode)
    {
        requestManager.RemoveRequest(actionCode);
    }
    public void ShowMessage(string str, bool sync = false)
    {
        uiManager.ShowMessage(str, sync);
    }
    public void SetSelfID(string id)
    {
        playerManager.CurrentPlayerID = id;
    }
    public void AddPlayer(MainPack packs)
    {
        playerManager.AddPlayer(packs);
    }
    public void RemovePlayer(string id)
    {
        playerManager.RemovePlayer(id);
    }
    public void GameExit()
    {
        playerManager.GameExit();
        uiManager.PopPanel();//Back to roomPanel
        uiManager.PopPanel();//back to HallPanel
        //uiManager.PopAndReternNext().GetComponent<RoomListPanel>().findRoomRequest.SendRequest();
    }
    //public void LoadScene(int num)
    //{
    //    SceneManager.LoadScene(num);
    //}    
    public void UpPos(MainPack pack)
    {
        playerManager.UpPos(pack);
    }
    public void InitManager()
    {
        uiManager = new UIManager(this);
        //clientManager = new ClientManager(this);
        //clientManager.ip = serverIPStr;
        requestManager = new RequestManager(this);
        playerManager = new PlayerManager(this);


        uiManager.OnInit();
        //clientManager.OnInit();
        requestManager.OnInit();
        playerManager.OnInit();
    }
}
