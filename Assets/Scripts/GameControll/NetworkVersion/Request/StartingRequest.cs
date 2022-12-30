using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;
using System.Linq;
using UnityEngine.SceneManagement;

public class StartingRequest : BasicRequest
{
    private MainPack isStart = null;
    private MainPack isStartCopy = null;
    public RoomPanel roomPanel;
    public override void Awake()
    {
        actionCode = ActionCode.Starting;
        base.Awake();
    }
    private void Update()
    {
        if(isStart != null)
        {
            Debug.Log("游戏正式开始");
            //gameController.LoadScene(1);
            isStartCopy = isStart;
            StartCoroutine(Load());
            //gameController.AddPlayer(isStart);
            //Debug.Log(isStartCopy.Playerpack.ToString());
            //roomPanel = gameObject.GetComponent<RoomPanel>();
            //roomPanel.GameStarting(isStart);
            isStart = null;
        }        
    }
    IEnumerator Load()
    {

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        Debug.Log("完成加载" + SceneManager.GetActiveScene().name);
        //create player
        gameController.AddPlayer(isStartCopy);
        Debug.Log(isStartCopy.Playerpack.ToString());
        roomPanel = gameObject.GetComponent<RoomPanel>();
        roomPanel.GameStarting(isStartCopy);
        isStartCopy = null;
    }
    public override void OnResponse(MainPack pack)
    {
        isStart = pack;
    }
}
