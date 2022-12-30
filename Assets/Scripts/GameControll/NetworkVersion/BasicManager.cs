using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicManager
{
    protected GameController gameController;

    public BasicManager(GameController gameController)
    {
        this.gameController = gameController;
    }

    public virtual void OnInit()
    {

    }

    public virtual void OnDestroy()
    {

    }
}
