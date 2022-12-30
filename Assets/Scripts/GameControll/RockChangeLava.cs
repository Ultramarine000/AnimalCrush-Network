using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockChangeLava : MonoBehaviour
{
    public int changeTimes = 0;
    public GameObject rockCube;
    public GameObject lavaCube;
    public GameObject magmaCube;
    public LayerMask magmaLayer;
    public LayerMask lavaLayer;
    public LayerMask groundLayer;
    [SerializeField]
    private bool isChangeMagma = false;
    private bool isChangeLava = false;

    private Vector3 location;

    private void Start()
    {
        location = this.transform.position;
    }
    private void Update()
    {
        Debug.Log(changeTimes);
        this.transform.position = Vector3.MoveTowards(this.transform.position,location,0.3f*Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            ChangeLava();
            
        }
    }

    private void CheckAround()
    {
        if(isChangeLava && changeTimes<2)
        {
            RaycastHit hit;
            bool leftCheck = Physics.Raycast(this.transform.position, Vector3.left,out hit, 2f, groundLayer);
            if(leftCheck)
            {
                hit.collider.gameObject.GetComponent<RockChangeLava>().changeTimes = this.changeTimes + 1;
                hit.collider.gameObject.SendMessage("ChangeMagma");
            }
            bool rightCheck = Physics.Raycast(this.transform.position, Vector3.left*-1,out hit, 2f, groundLayer);
            if(rightCheck)
            {
                hit.collider.gameObject.GetComponent<RockChangeLava>().changeTimes = this.changeTimes + 1;
                hit.collider.gameObject.SendMessage("ChangeMagma");
            }
            bool fowardCheck = Physics.Raycast(this.transform.position, Vector3.forward,out hit, 2f, groundLayer);
            if(fowardCheck)
            {
                hit.collider.gameObject.GetComponent<RockChangeLava>().changeTimes = this.changeTimes + 1;
                hit.collider.gameObject.SendMessage("ChangeMagma");
            }
            bool backCheck = Physics.Raycast(this.transform.position, Vector3.forward*-1,out hit, 2f, groundLayer);
            if(backCheck)
            {
                hit.collider.gameObject.GetComponent<RockChangeLava>().changeTimes = this.changeTimes + 1;
                hit.collider.gameObject.SendMessage("ChangeMagma");
            }
        }

    }

    private void ChangeMagma()
    {
        if(!isChangeLava && !isChangeMagma)
        {
            this.transform.position += new Vector3(0,0.4f,0);
            rockCube.SetActive(false);
            magmaCube.SetActive(true);
            isChangeMagma = true;
            isChangeLava = false;
            Invoke("ChangeLava",5);
        }
    }

    private void ChangeLava()
    {
        if(!isChangeLava)
        {
            this.transform.position += new Vector3(0,0.4f,0);
            rockCube.SetActive(false);
            magmaCube.SetActive(false);
            lavaCube.SetActive(true);
            isChangeLava = true;
            isChangeMagma = false;
            CheckAround();
            changeTimes = 0;
        }
    }


}

