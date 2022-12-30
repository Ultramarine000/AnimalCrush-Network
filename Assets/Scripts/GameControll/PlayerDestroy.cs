using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;

public class PlayerDestroy : BasicPanel
{
    //public WinnerCheckRequest winnerCheckRequest;
    public GamePanel gamePanel;
    //public GameExitRequest gameExitRequest;

    //protected GameController gameController
    //{
    //    get
    //    {
    //        return GameController.Controller;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //winnerCheckRequest.SendRequest();
            gamePanel = FindObjectOfType<GamePanel>();
            //gameController.RemoveRequest(ActionCode.ExitGame);
            //gameExitRequest.SendRequest();
            //gameController.GameExit();

            //Destroy(other.gameObject);
            //Debug.Log("Fall dead");

            gamePanel.PushGameOver();
        }
    }
}
