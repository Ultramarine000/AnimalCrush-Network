using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPanel : MonoBehaviour
{
    protected UIManager uiManager;
    protected GameController gameController
    {
        get
        {
            return GameController.Controller;
        }
    }
    public UIManager SetUIMsg
    {
        set { uiManager = value; }
    }
    public virtual void OnEnter()
    {

    }
    public virtual void OnPause()
    {

    }
    public virtual void OnResuem()
    {

    }
    public virtual void OnExit()
    {

    }
}
