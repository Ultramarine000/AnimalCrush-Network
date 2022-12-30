using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkTest;

public class RoomListPanel : BasicPanel
{
    public Button back, search, create;
    public InputField roomName;
    public Slider num;

    public Transform roomListTransform;
    public GameObject roomItem;

    public CreateRoomRequest createRoomRequest;
    public FindRoomRequest findRoomRequest;
    public JoinRoomRequest joinRoomRequest;
    private void Start()
    {
        back.onClick.AddListener(OnBackClick);
        search.onClick.AddListener(OnFindClick);
        create.onClick.AddListener(OnCreateClick);
    }
    private void OnBackClick()
    {
        uiManager.PopPanel();
    }
    private void OnFindClick()
    {
        findRoomRequest.SendRequest();
    }
    private void OnCreateClick()
    {
        if(roomName.text == "")
        {
            uiManager.ShowMessage("Room Name cannnot set null");
            return;
        }
        createRoomRequest.SendRequest(roomName.text, (int)num.value);
    }
    public void CreateRoomResponse(MainPack pack)
    {
        switch (pack.ReturnCode)
        {
            case ReturnCode.Succeed:
                //Debug.Log("Logon Succeed");
                uiManager.ShowMessage("Create room successfully");
                RoomPanel roomPanel = uiManager.PushPanel(PanelType.Room).GetComponent<RoomPanel>();
                roomPanel.UpdatePlayerList(pack);
                break;
            case ReturnCode.Fail:
                //Debug.LogWarning("Logon Failed");
                uiManager.ShowMessage("Create room failed");
                break;
            default:
                Debug.Log("Create room def");
                break;
        }
    }
    public void FindRoomResponse(MainPack pack)
    {
        switch (pack.ReturnCode)
        {
            case ReturnCode.Succeed:
                uiManager.ShowMessage("Find " + pack.Roompack.Count + " room(s) successfully"); 
                break;
            case ReturnCode.Fail:
                //Debug.LogWarning("Logon Failed");
                uiManager.ShowMessage("Find room failed");
                break;
            case ReturnCode.NoRoom:
                //Debug.LogWarning("Logon Failed");
                uiManager.ShowMessage("Can't find the room");
                break;
            default:
                Debug.Log("Create room def");
                break;
        }
        UpdateRoomList(pack);
    }
    private void UpdateRoomList(MainPack pack)
    {
        //clear roomList
        for(int i = 0; i < roomListTransform.childCount; i++)
        {
            Destroy(roomListTransform.GetChild(i).gameObject);
        }
        if(pack.Roompack.Count == 0) { return; }
        foreach(RoomPack room in pack.Roompack)
        {
            RoomItem item = Instantiate(roomItem, Vector3.zero, Quaternion.identity).GetComponent<RoomItem>();
            item.roomListPanel = this;
            item.gameObject.transform.SetParent(roomListTransform);
            item.SetRoomInfo(room.Roomname, room.Curnum, room.Maxnum, room.Status);
        }
    }

    public void JoinRoomResponse(MainPack pack)
    {
        switch (pack.ReturnCode)
        {
            case ReturnCode.Succeed:
                uiManager.ShowMessage("Join in room successfully");
                RoomPanel roomPanel = uiManager.PushPanel(PanelType.Room).GetComponent<RoomPanel>();
                roomPanel.UpdatePlayerList(pack);
                break;
            case ReturnCode.Fail:
                uiManager.ShowMessage("Join in room failed");
                break;
            default:
                uiManager.ShowMessage("Try refreshing");
                break;
        }
    }

    public void JoinRoom(string roomname)
    {
        joinRoomRequest.SendRequest(roomname);
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
