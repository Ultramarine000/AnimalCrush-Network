using NetworkTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestManager : BasicManager
{
    public RequestManager(GameController gameController) : base(gameController) { }

    private Dictionary<ActionCode, BasicRequest> requestDict = new Dictionary<ActionCode, BasicRequest>();
    
    public void AddRequest(BasicRequest request)
    {
        requestDict.Add(request.GetActionCode, request);
    }
    public void RemoveRequest(ActionCode action)
    {
        requestDict.Remove(action);
    }

    public void HandleResponse(MainPack pack)
    {
        Debug.Log("RM got AC: " + pack.ActionCode.ToString());
        if (requestDict.TryGetValue(pack.ActionCode, out BasicRequest request))
        {
            request.OnResponse(pack);
            //Debug.Log("handle?");
        }
        else
        {
            //Debug.Log(pack.ActionCode.ToString()+ pack.RequestCode.ToString());
            Debug.Log("Cannot find relevent handle method");
        }
    }
}
