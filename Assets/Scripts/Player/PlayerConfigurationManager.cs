using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;
    [SerializeField]
    private int MaxPlayers = 4;
    public GameObject title;
    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a seccond instance of a singleton class.");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
        
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("player joined " + pi.playerIndex);
        //--------------
        title.SetActive(false);
        pi.transform.SetParent(transform);

        if(!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))//确保已经加入了这个角色
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigs[index].playerMaterial = color;
    }
    public void SetPlayerModel(int index, int modeIndex)
    {
        playerConfigs[index].modeIndex = modeIndex;
    }
    public void SetPlayerMap(int index, int mapIndex)
    {
        playerConfigs[index].mapIndex = mapIndex;
    }
    public void SetLastWinnerIndex(int index, int winnerIndex)
    {
        playerConfigs[index].lastWinnerIndex = winnerIndex;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            if(playerConfigs[0].mapIndex == 0) SceneManager.LoadScene("0-River");
            else if (playerConfigs[0].mapIndex == 1) SceneManager.LoadScene("1-Ice");
            else if (playerConfigs[0].mapIndex == 2) SceneManager.LoadScene("2-Magma");
            else if (playerConfigs[0].mapIndex == 3) SceneManager.LoadScene("3-Sand");
        }
    }
}

public class PlayerConfiguration//玩家配置类
{
    public PlayerConfiguration(PlayerInput pi)//传入输入信号pi以创建一个PlayerConfiguration
    {
        PlayerIndex = pi.playerIndex;//创建时传入的pi中包含的编号作为玩家编号记录
        Input = pi;//pi单独作为Input存起来
    }

    public PlayerInput Input { get; private set; }
    public int PlayerIndex { get; private set; }
    public bool isReady { get; set; }
    public Material playerMaterial {get; set;}
    public int modeIndex { get; set; }
    public int mapIndex { get; set; }
    public int lastWinnerIndex { get; set; }
}