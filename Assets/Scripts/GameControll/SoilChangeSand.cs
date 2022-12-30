using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilChangeSand : MonoBehaviour
{
    public GameObject driedSoidCube;
    public GameObject sandCube;
    [SerializeField]
    private bool canBeSandy;

    private float waitTime = 10.0f;
    private float timer = 0.0f;

    private void Update()
    {
        if(canBeSandy)
        {
            sandCube.transform.parent.transform.position += new Vector3(0, -0.003f, 0);
            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                //Debug.Log("Destroy sand3");
                Destroy(gameObject);
            }
        }
            
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            driedSoidCube.SetActive(false);
            sandCube.SetActive(true);
            canBeSandy = true;
        }
        if (other.gameObject.tag == "Sand Destroy")
        {
            Destroy(gameObject);
        }
    }
}
