using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteCharacter : MonoBehaviour
{
    private Transform selfTransform;

    private Vector3 selfPos;
    private Quaternion selfAngle;

    public void SetState(Vector3 selfpos, float selfangle)
    {
        selfPos = selfpos;
        selfAngle = Quaternion.Euler(0, selfangle, 0);
    }
    private void Start()
    {
        selfTransform = transform;
        selfAngle = selfTransform.rotation;
        selfPos = selfTransform.position;
    }

    void Update()
    {
        if(selfTransform == null || selfPos == null) return;
        selfTransform.position = Vector3.Lerp(selfTransform.position, selfPos, 0.25f);
        selfTransform.rotation = Quaternion.Slerp(selfTransform.rotation, selfAngle, 0.25f);
        //Debug.Log(selfTransform.position.ToString());
    }
}
