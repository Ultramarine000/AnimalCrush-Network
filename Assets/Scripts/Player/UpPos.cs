using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPos : MonoBehaviour
{
    private UpPosRequest upPosRequest;
    void Start()
    {
        upPosRequest = GetComponent<UpPosRequest>();
        //30 frame/s
        InvokeRepeating("UpPosFun", 1, 1f / 10f);
    }
    private void UpPosFun()
    {
        Vector3 pos = transform.position;
        float charRot = transform.eulerAngles.y;
        upPosRequest.SendRequest(pos, charRot);
    }
}
