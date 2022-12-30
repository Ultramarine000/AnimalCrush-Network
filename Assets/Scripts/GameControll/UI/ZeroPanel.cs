using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class ZeroPanel : BasicPanel
{
    public InputField serverIP;
    public Button enterBtn;
    //public GameObject gamecontroller;
    public static string serverIPStr;

    private void Start()
    {
        enterBtn.onClick.AddListener(OnEnterClick);
    }
    private void OnEnterClick()
    {
        //Debug.Log("click");
        if (serverIP.text == null)
        {
            //Debug.Log("Must input server IP");
            return;
        }
        //serverIPStr = serverIP.text;

        //gamecontroller.GetComponent<GameController>().serverIPStr = serverIPStr;
        //gamecontroller.SetActive(true);
        //gameController.haveIP = true;
        //GameObject gc = GameObject.Instantiate(Resources.Load("Panel/GameController") as GameObject);

        //SceneManager.LoadScene("LogTest");
        //ScriptableObject scriptable = IPSO.CreateInstance<IPSO>();
        //string path = string.Format("Assets/Resources/IPSO.asset");
        //AssetDatabase.CreateAsset(scriptable, path);

        IPSO DataIP = Resources.Load<IPSO>("DataIP");
        DataIP.IP = null;
        DataIP.IP = serverIP.text;
        SceneManager.LoadScene("LogTest");

        //this.gameObject.SetActive(false);
        //uiManager.PushPanel(PanelType.Start);
    }

}
