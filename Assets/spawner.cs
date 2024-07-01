using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public bool spawnerOn;
    public int numOfDucks;
    public float fireRate;

    public Transform one, two, three, four;

    public GameObject duck;

    private Rigidbody rb;
    // Update is called once per frame

    void Start()
    {
        if (spawnerOn)
        {
            Invoke("myFunction", fireRate);
        }
        
    }

    void myFunction()
    {
        if (numOfDucks > 3)
        {
            fire(Instantiate(duck, four.position, four.rotation));
        }
        if (numOfDucks > 2)
        {
            fire(Instantiate(duck, three.position, three.rotation));
        }
        if (numOfDucks > 1)
        {
            fire(Instantiate(duck, two.position, two.rotation));
        }
        if (numOfDucks > 0)
        {
            fire(Instantiate(duck, one.position, one.rotation));
        }

        if (spawnerOn)
        {
            Invoke("myFunction", fireRate);
        }
    }

    void fire(GameObject go)
    {
        rb = go.GetComponent<Rigidbody>();
        rb.velocity = go.transform.forward * 10;
    }
}
