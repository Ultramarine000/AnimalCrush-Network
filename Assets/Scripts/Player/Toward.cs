using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Toward : MonoBehaviour
{
    private Vector2 inputVector = Vector2.zero;
    void Start()
    {
        
    }
    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    void Update()
    {
        if(inputVector.magnitude>0.1f)
            transform.DOLookAt(new Vector3 (inputVector.x, 0, inputVector.y) + transform.position,0.2f);
        
    }
}
