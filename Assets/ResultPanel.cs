using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : BasicPanel
{
    public Button quitBtn;
    //public GameExitRequest gameExitRequest;
    //public PlayerDestroy playerDestroy;
    //[SerializeField]
    private GamePanel gamePanel;

    private void Start()
    {
        //gamePanel = FindObjectOfType<GamePanel>();
        //playerDestroy = FindObjectOfType<PlayerDestroy>();
        quitBtn.onClick.AddListener(OnExitClick);
    }

    private void OnExitClick()
    {
        //playerDestroy.
        uiManager.PushPanel(PanelType.Game);
        gamePanel = FindObjectOfType<GamePanel>();
        gamePanel.gameExitRequest.SendRequest();
        gameController.GameExit();
        //uiManager.PushPanel(PanelType.RoomList);
        this.gameObject.SetActive(false);
    }
}
