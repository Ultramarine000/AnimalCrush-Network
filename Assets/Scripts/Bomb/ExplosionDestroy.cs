using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExplosionDestroy : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        Invoke("removeCollider", 0.2f);

    }

    void Update()
    {
        bool allStopped = true;

        foreach (ParticleSystem ps in particleSystems)
        {
            if (!ps.isStopped)
            {
                allStopped = false;
            }
        }

        if (allStopped)
            GameObject.Destroy(gameObject);
    }

    void removeCollider()
    {
        GameObject.Destroy(this.GetComponent<SphereCollider>());
    }
}
