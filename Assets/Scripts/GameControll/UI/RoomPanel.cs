using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkTest;

public class RoomPanel : BasicPanel
{
    public Button backBtn, sendBtn, startBtn;
    public InputField inputText;
    public Scrollbar scrollbar;

    public Text chatText;
    public Transform content;
    public GameObject userItemPrefab;

    public ExitRoomRequest exitRoomRequest;
    public ChatRequest chatRequest;
    public StartGameRequest startGameRequest;

    private void Start()
    {
        backBtn.onClick.AddListener(OnBackClick);
        sendBtn.onClick.AddListener(OnSendClick);
        startBtn.onClick.AddListener(OnStartClick);
    }

    private void OnBackClick()
    {
        exitRoomRequest.SendRequest();
    }
    private void OnSendClick()
    {
        if(inputText.text == "")
        {
            uiManager.ShowMessage("Sending content cannot be empty");
            return;
        }
        chatRequest.SendRequest(inputText.text);
        chatText.text += "Me: " + inputText.text + '\n';
        inputText.text = "";
    }
    private void OnStartClick()
    {
        startGameRequest.SendRequest();
    }
    //Refresh player list
    public void UpdatePlayerList(MainPack pack)
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        foreach(PlayerPack player in pack.Playerpack)
        {
            UserItem userItem = Instantiate(userItemPrefab, Vector3.zero, Quaternion.identity).GetComponent<UserItem>();
            userItem.gameObject.transform.SetParent(content);
            userItem.SetPlayerInfo(player.Playername);
        }
    }

    public void ExitRoomResponse()
    {
        //uiManager.PopPanel();
        uiManager.PopAndReternNext().GetComponent<RoomListPanel>().findRoomRequest.SendRequest();
    }

    public void ChatResopnse(string str)
    {
        chatText.text += str + '\n';
    }
    public void StartGameResponse(MainPack pack)
    {
        switch(pack.ReturnCode)
        {
            case ReturnCode.Fail:
                uiManager.ShowMessage("Only the host can start a game");
                break;
            case ReturnCode.Succeed:
                uiManager.ShowMessage("Game start");
                break;
            default:
                uiManager.ShowMessage("Try refreshing");
                break;
        }   
    }

    public void GameStarting(MainPack pack)
    {
        GamePanel gamePanel = uiManager.PushPanel(PanelType.Game).GetComponent<GamePanel>();
        gamePanel.UpdateList(pack);
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
