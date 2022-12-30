using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkTest;

public class GamePanel : BasicPanel
{
    public GameObject item;
    public Transform listTransform;
    //public Text timeText;
    public Button quitBtn;
    public GameExitRequest gameExitRequest;

    

    private Dictionary<string, PlayerInfoItem> itemList = new Dictionary<string, PlayerInfoItem>();

    private void Start()
    {
        quitBtn.onClick.AddListener(OnExitClick);
    }

    public void UpdateList(MainPack packs)
    {
        for (int i = 0; i < listTransform.childCount; i++)
        {
            GameObject.Destroy(listTransform.GetChild(i).gameObject);
        }
        itemList.Clear();
        foreach(var p in packs.Playerpack)
        {
            GameObject g= Instantiate(item, Vector3.zero, Quaternion.identity);
            g.transform.SetParent(listTransform);            
            PlayerInfoItem pInfo = g.GetComponent<PlayerInfoItem>();
            pInfo.Set(p.Playername, p.Hp);
            itemList.Add(p.Playername, pInfo);
        }
    }
    public void UpdateValue(string id, int v)
    {
        if(itemList.TryGetValue(id, out PlayerInfoItem pInfo))
        {
            pInfo.Up(v);
        }
        else
        {
            Debug.Log("Cannot get relevent playerInfo");
        }
    }

    //private void FixedUpdate()
    //{
    //    //timeText.text = ((int)Time.time).ToString();
    //    //if (listTransform.childCount == 1)
    //    //{
    //    //    uiManager.PushPanel(PanelType.Gameover);
    //    //}
    //}
    public void PushGameOver()
    {
        uiManager.PushPanel(PanelType.Gameover);
    }
    private void OnExitClick()
    {
        gameExitRequest.SendRequest();
        gameController.GameExit();
    }


    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("enter room");
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
