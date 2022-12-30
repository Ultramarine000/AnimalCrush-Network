using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{   

    public GameObject Bomb;
    public float startTime = 0.5f;
    public float refreshTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BombInstantiate();

    }

    void BombInstantiate()
    {
        
        startTime -= Time.deltaTime;
        if (startTime <= 0)
        {
            int x = Random.Range(-8, 8);
            int z = Random.Range(-12, 8);
            Vector3 bombPosition = new Vector3(x, 30, z);
            Instantiate(Bomb, bombPosition, transform.rotation);
            startTime = refreshTime;
        }
    }
}
