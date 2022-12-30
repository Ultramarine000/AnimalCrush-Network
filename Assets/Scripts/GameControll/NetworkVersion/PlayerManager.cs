using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;
using System;
using UnityEngine.SceneManagement;

public class PlayerManager : BasicManager
{
    public PlayerManager(GameController gameController) : base(gameController) { }

    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    private GameObject character;
    private Transform spawnPos;

    public override void OnInit()
    {
        base.OnInit();
        //character = Resources.Load<GameObject>("Player/OriPrefab");
        character = Resources.Load<GameObject>("Player/OriPrefab");
    }

    public string CurrentPlayerID 
    { 
        get; 
        set; 
    }

    public void AddPlayer(MainPack pack)
    {
        //spawnPos = GameObject.Find("SpawnPos").transform;
        //int posindex = -4;
        int offset = 10;
        int offset2 = 0;
        Vector3 pos = new Vector3(-7f, 4f, -10f);
        Vector3 pos2 = new Vector3(-7f + 13f, 4f, -10f);
        Vector3 pos3 = new Vector3(-7f, 4f, -10f + 13f);
        Vector3 pos4 = new Vector3(-7f + 13f, 4f, -10f + 13f);
        int i = 0;
        foreach (var p in pack.Playerpack)
        {
            //Debug.Log("addplayer: " + p.Playername);
            //Debug.Log(SceneManager.GetActiveScene().name);
            //Vector3 pos = new Vector3(-5.76f, 3.76f, -9.86f);
            Vector3[] posArr = new Vector3[]{pos, pos2, pos3, pos4};
            GameObject g = GameObject.Instantiate(character, posArr[i++], Quaternion.identity);
            //pos.x += offset;
            //pos.z += offset2;
            //i++;
            if (p.Playername.Equals(gameController.UserName))
            {
                //create local player
                g.AddComponent<UpPosRequest>();
                g.AddComponent<UpPos>();
                g.GetComponent<Mover>().enabled = true;
            }
            else
            {
                g.AddComponent<RemoteCharacter>();
            }
            //create players of other clients'
            players.Add(p.Playername, g);
        }
    }
    public void RemovePlayer(string id)
    {
        if(players.TryGetValue(id, out GameObject g))
        {
            GameObject.Destroy(g);
            players.Remove(id);
        }
        else
        {
            Debug.Log("error when remove player");
        }
    }
    public void GameExit()
    {
        foreach(var VARIABLE in players.Values)
        {
            //clear player
            GameObject.Destroy(VARIABLE);
        }
        players.Clear();
    }

    public void UpPos(MainPack pack)
    {
        PosPack posPack = pack.Playerpack[0].Pospack;
        if (players.TryGetValue(pack.Playerpack[0].Playername, out GameObject g ))
        {
            Vector3 pos = new Vector3(posPack.PosX, posPack.PosY, posPack.PosZ);
            float CharRot = posPack.RotY;
            //g.transform.position = pos;
            //g.transform.eulerAngles = new Vector3(0, CharRot, 0);
            g.GetComponent<RemoteCharacter>().SetState(pos, CharRot);
        }
        //if(pack.Playerpack[0].Playername == "111")
        //{
        //    gameController.isRec = true;
        //}
    }
}
