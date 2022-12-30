using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public GameObject PreAim;

    void Start()
    {
        Ray ray;
        ray = new Ray(this.transform.position,transform.up*-1);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, 500,1<<8))
        {
                Instantiate(PreAim,hit.point-new Vector3(0,-0.1f,0),Quaternion.Euler(90f,0f,0f));
        }
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(ExplosionPrefab,transform.position,Quaternion.Euler(-90f,0f,0f));
        Destroy(this.gameObject);
    }
}
