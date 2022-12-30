using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowChangeIce : MonoBehaviour
{
    public GameObject iceCube;
    public GameObject snowCube;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bomb")
        {
            snowCube.SetActive(false);
            iceCube.SetActive(true);
        }
    }
}
