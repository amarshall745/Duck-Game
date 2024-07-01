using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    public bool destroySelf;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyParticle", timer);
    }

    public void destroyParticle()
    {
        if (destroySelf)
        {
            Destroy(gameObject);
        }
    }
}
