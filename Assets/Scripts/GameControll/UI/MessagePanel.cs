using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasicPanel
{
    public Text text;
    private string msg = null;
    public override void OnEnter()
    {
        base.OnEnter();
        text.CrossFadeAlpha(0, 0.1f, false);
        uiManager.SetMessagePanel(this);
    }
    private void Update()
    {
        if(msg != null)
        {
            ShowText(msg);
            msg = null;
        }
    }
    private void ShowText(string str)
    {
        text.text = str;
        text.CrossFadeAlpha(1, 0.1f, false);
        Invoke("HideText", 1);
        //Debug.Log(str);
    }
    public void ShowMessage(string  str, bool sync = false)
    {
        if(sync)
        {
            //异步显示
            msg = str;
        }
        else
        {
            ShowText(str);            
        }
    }
    private void HideText()
    {
        text.CrossFadeAlpha(0, 1f, false);
    }
}
