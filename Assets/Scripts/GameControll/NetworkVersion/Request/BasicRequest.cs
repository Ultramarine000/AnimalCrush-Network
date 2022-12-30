using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkTest;
using System;

public class BasicRequest : MonoBehaviour
{
    protected RequestCode requestCode;
    protected ActionCode actionCode;
    protected GameController gameController;
    public ActionCode GetActionCode { get { return actionCode; } }

    public virtual void Awake()
    {
        gameController = GameController.Controller;        
    }
    public virtual void Start()
    {
        gameController.AddRequest(this);
        //Debug.Log("Add: " + actionCode.ToString());
    }
    public virtual void OnDestory()
    {
        gameController.RemoveRequest(actionCode);
    }

    public virtual void OnResponse(MainPack pack)
    {

    }
    public virtual void SendRequest(MainPack pack)
    {
        gameController.Send(pack);
    }
    public virtual void SendRequestUDP(MainPack pack)
    {
        gameController.SendTo(pack);
    }
}
