using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    //public GameObject controller;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.other.tag == "Bomb")
         {
            Debug.Log("hitbomb");
            var Father = gameObject.transform.parent.gameObject;
            isDead = true;
            Destroy(Father);          
         }   
    }

}
