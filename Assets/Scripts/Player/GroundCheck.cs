using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("地面环境检测")]
    public float footOffset = 0.4f;
    float playerHeight = 1;
    public LayerMask groundLayer;
    public LayerMask iceLayer;
    [SerializeField]
    private bool isOnGround = false;
    [SerializeField]
    private bool isOnIce = false;
    void Start()
    {
        
    }
    void Update()
    {
        PhysicsCheck();
    }
    void PhysicsCheck()
    {
        bool leftFrontCheck = Raycast(new Vector3(-footOffset, 0.5f, footOffset), Vector3.down, 5, iceLayer);
        bool rightFrontCheck = Raycast(new Vector3(footOffset, 0.5f, footOffset), Vector3.down, 5, iceLayer);
        bool leftBackCheck = Raycast(new Vector3(-footOffset, 0.5f, -footOffset), Vector3.down, 5, iceLayer);
        bool rightBackCheck = Raycast(new Vector3(footOffset, 0.5f, -footOffset), Vector3.down, 5, iceLayer);
        if (leftFrontCheck || rightFrontCheck || leftBackCheck || rightBackCheck)
            isOnIce = true;
        else
            isOnIce = false;
    }
    bool Raycast(Vector3 offset, Vector3 rayDirection, float length, LayerMask layer)
    {
        Vector3 pos = transform.position;

        bool hit = Physics.Raycast(pos + offset, rayDirection, length, layer);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return hit;
    }
}
