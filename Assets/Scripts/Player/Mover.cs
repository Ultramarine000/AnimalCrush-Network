using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.InputSystem.XR.Haptics;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    //[Header("Network")]
    //public float sendCD;
    [Header("速度")]
    public float groundMoveSpeed = 7f;
    public float IceMoveSpeed = 0.85f;

    public Rigidbody rb;    

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;
    private PlayerInputHandler pih;

    [Header("环境检测")]
    public float footOffset = 0.4f;
    float playerHeight = 1;
    public float floatingSpeed = 200;
    public LayerMask groundLayer;
    public LayerMask iceLayer;
    public LayerMask waterLayer;
    [SerializeField]
    public bool isOnGround = false;
    [SerializeField]
    private bool isOnIce = false;
    [SerializeField]
    private bool isOnWater = false;
    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pih = GetComponent<PlayerInputHandler>();
    }
    

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }
    void Update()
    {
        PhysicsCheck();
        OnMove();        
    }
    void PhysicsCheck()
    {
        bool leftFrontCheckIce = Raycast(new Vector3(-footOffset, 0.5f, footOffset), Vector3.down, 0.7f, iceLayer);
        bool rightFrontCheckIce = Raycast(new Vector3(footOffset, 0.5f, footOffset), Vector3.down, 0.7f, iceLayer);
        bool leftBackCheckIce = Raycast(new Vector3(-footOffset, 0.5f, -footOffset), Vector3.down, 0.7f, iceLayer);
        bool rightBackCheckIce = Raycast(new Vector3(footOffset, 0.5f, -footOffset), Vector3.down, 0.7f, iceLayer);

        bool leftFrontCheckGround = Raycast(new Vector3(-footOffset - 0.1f, 0.5f, footOffset + 0.1f), Vector3.down, 1f, groundLayer);
        bool rightFrontCheckGround = Raycast(new Vector3(footOffset + 0.1f, 0.5f, footOffset + 0.1f), Vector3.down, 1f, groundLayer);
        bool leftBackCheckGround = Raycast(new Vector3(-footOffset - 0.1f, 0.5f, -footOffset - 0.1f), Vector3.down, 1f, groundLayer);
        bool rightBackCheckGround = Raycast(new Vector3(footOffset + 0.1f, 0.5f, -footOffset - 0.1f), Vector3.down, 1f, groundLayer);

        bool leftFrontCheckWater = Raycast(new Vector3(-footOffset, 0.5f, footOffset), Vector3.down, 1.5f, waterLayer);
        bool rightFrontCheckWater = Raycast(new Vector3(footOffset, 0.5f, footOffset), Vector3.down, 1.5f, waterLayer);
        bool leftBackCheckWater = Raycast(new Vector3(-footOffset, 0.5f, -footOffset), Vector3.down, 1.5f, waterLayer);
        bool rightBackCheckWater = Raycast(new Vector3(footOffset, 0.5f, -footOffset), Vector3.down, 1.5f, waterLayer);

        if (leftFrontCheckIce || rightFrontCheckIce || leftBackCheckIce || rightBackCheckIce)//冰检测
            isOnIce = true;
        else
            isOnIce = false;

        if (leftFrontCheckWater || rightFrontCheckWater || leftBackCheckWater || rightBackCheckWater)
            isOnWater = true;
        else
            isOnWater = false;

        //只要在冰上就在地上
        if (isOnIce || leftFrontCheckGround || rightFrontCheckGround || leftBackCheckGround || rightBackCheckGround)
        {
            isOnGround = true;
        }
        else
            isOnGround = false;
    }
    bool Raycast(Vector3 offset, Vector3 rayDirection, float length, LayerMask layer)
    {
        Vector3 pos = transform.position;

        bool hit = Physics.Raycast(pos + offset, rayDirection, length, layer);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return hit;
    }
    void OnMove()
    {
        float inputHor = Input.GetAxis("Horizontal");
        float inputVer = Input.GetAxis("Vertical");
        if (isOnIce)//冰上移动
        {
            //rb.velocity += new Vector3(pih.processiveForce.x, 0, pih.processiveForce.z) * IceMoveSpeed;
            rb.velocity += new Vector3(inputHor, 0, inputVer) * IceMoveSpeed;
            

        }
        else//平地移动
        {
            //rb.velocity = new Vector3(pih.processiveForce.x * groundMoveSpeed, rb.velocity.y, pih.processiveForce.z * groundMoveSpeed);
            rb.velocity = new Vector3(inputHor * groundMoveSpeed, rb.velocity.y, inputVer * groundMoveSpeed);
            if (isOnWater)
            {
                Vector3 waterDir = (new Vector3(0, 0.05f, -0.42f) - gameObject.transform.position).normalized;
                waterDir.y = 0;
                rb.AddForce(waterDir * floatingSpeed);
            }            
        }

        if (rb.velocity.x != 0 || rb.velocity.z != 0)
        {
            //anim.SetBool("Idle", false);
            //anim.SetTrigger("Run");
            float angle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
        //else
        //{
        //    anim.SetBool("Idle", true);
        //}
    }
}
