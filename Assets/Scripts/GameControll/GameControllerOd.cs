using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControllerOd : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private TextMeshProUGUI settleText;
    public static List<GameObject> playerList = new List<GameObject>();
    public GameObject continuePanel;

    public int playerCount = 0 ;

    public float CountDownTime;
    private float GameTime;
    private float timer = 0;

    private bool[] isdead = new bool[4];
    public Text GameCountTimeText;
    public PlayerConfiguration[] playerConfigs;
    void Awake()
    {   
        GameTime = CountDownTime;
        //获取playerConfig
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i <  playerConfigs.Length; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
            player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfigs[i]);
            playerList.Add(player.gameObject);
            playerCount++;
        }
        
    }

    void Update()
    {   //Debug.Log(playerCount);
        int M = (int)(GameTime / 60);
        float S = GameTime % 60;
        timer += Time.deltaTime;
        if(timer>=1f)
        {
            timer = 0;
            GameTime--;
            GameCountTimeText.text = M + "：" + string.Format("{0:00}", S);
        }
        
        
        for(int i = 0; i < playerList.Count;i++)
        {            
            if(playerList[i] == null)
            {
                //Debug.Log(i);
                isdead[i] = true;                
            }
        }
        
        /*if(GameTime == 0)
        {
         GameOver();   
        }*/
        IsWin();
    }
    void IsWin()
    {
        int isAlive = playerCount;
        for(int i = 0; i < playerList.Count;i++)
        {
            if(isdead[i] == true)
            {
                isAlive --;
                
            }
        }
        if(isAlive == 1)
        {
            GameOver();
            isAlive = playerCount;
            playerList.Clear();           

        }
    }
    public void GameOver()
    {
        
     for(int i = 0; i < playerList.Count;i++)
        {
            Debug.Log("GameOver");
            if(playerList[i] != null)
            {
                Debug.Log("player"+(i+1)+"Win");
                

                for (int j = 0; j < playerCount; j++)
                {
                    PlayerConfigurationManager.Instance.SetLastWinnerIndex(j, i);
                    settleText.SetText("Player " + (i + 1).ToString() + " got the winner !");
                }                
                continuePanel.SetActive(true);
            }        
            
            
        }     
    }
    public void ChangeToSettleScene()
    {
        SceneManager.LoadScene("SettleAccount");
    }
}
