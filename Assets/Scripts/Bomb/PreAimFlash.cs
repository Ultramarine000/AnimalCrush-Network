using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreAimFlash : MonoBehaviour
{
    public float FlashTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlashTime -=Time.deltaTime;
        if(FlashTime>0f)
        {
            float remainder = FlashTime % 0.3f;
            this.GetComponent<Renderer>().enabled = remainder > 0.15f;
        }
        else {
            Destroy(this);
        }

        
    }
}
