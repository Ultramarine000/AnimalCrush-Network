using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using DG.Tweening;


public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private Mover mover;
    private Toward toward;
    public List<GameObject> Models;
    public Vector3 processiveForce = Vector3.zero;
    public int bounceForce;
    public float jumpForce = 1.8f;
    [SerializeField]
    private bool isDead = false;

    //[SerializeField]
    //private GameObject PlayerModel;
    //[SerializeField]
    //private MeshRenderer playerMesh;//换颜色用  

    private PlayerControls controls;
    private void Awake()    
    {
        mover = GetComponent<Mover>();
        toward = GetComponentInChildren<Toward>();
        controls = new PlayerControls();
    }
    

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        mover.anim = Models[pc.modeIndex].GetComponent<Animator>();
        Models[pc.modeIndex].SetActive(true);

        //mover = Models[pc.modeIndex].GetComponent<Mover>();
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if(obj.action.name == controls.PlayerMovementCube.Movement.name)
        {
            OnMove(obj);
        }
        if (obj.action.name == controls.PlayerMovementCube.Jump.name && mover.isOnGround)//按键且在地面上可跳
        {
            mover.rb.velocity += new Vector3(0, jumpForce, 0);
            mover.anim.SetTrigger("Jump");
        }
    }

    public void OnMove(CallbackContext context)
    {
        if(mover != null)
            
            {
                mover.SetInputVector(context.ReadValue<Vector2>());
                processiveForce = new Vector3(context.ReadValue<Vector2>().x, 0 , context.ReadValue<Vector2>().y);
                toward.SetInputVector(context.ReadValue<Vector2>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")//Rebound
        {
            Vector3 bounceDir = (this.transform.position - other.gameObject.transform.position).normalized;
            Vector3 bounceDirOther = -bounceDir;
            bounceDir = bounceDir * bounceForce;
            bounceDir.y = 0;
            this.transform.DOMove(this.transform.position + bounceDir, 0.3f).SetEase(Ease.OutSine);

            bounceDirOther = bounceDirOther * bounceForce;
            bounceDirOther.y = 0;
            //other.gameObject.transform.DOMove(other.transform.position + bounceDirOther, 0.3f).SetEase(Ease.OutQuad);
        }
        if (other.gameObject.tag == "Bomb")
        {
            Debug.Log("hitbomb");
            isDead = true;
            Destroy(gameObject);
        }
    }
}