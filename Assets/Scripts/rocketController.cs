using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketController : MonoBehaviour
{
    public float moveSpeed, lifeTime, explodeTime;

    public Rigidbody rb;

    public GameObject impactEffect;
    public bool selfDestroy;

    private bool canCountdown = false;
    private bool explode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (canCountdown)
        {
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0)
            {
                Destroy(gameObject);
                Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            }
        }

        if (explode)
        {
            explodeTime -= Time.deltaTime;

            if (explodeTime <= 0)
            {
                Destroy(gameObject);
                Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int layerMask = other.gameObject.layer;

        if (layerMask == 6)
        {
            //Debug.Log("BOOM");
            Destroy(other.gameObject);
            Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
            if (selfDestroy)
            {
                //Destroy(gameObject);
                Debug.Log("Start exploding");
                explode = true;
            }
        }
        else
        {
            if (selfDestroy)
            {
                Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    public void Countdown()
    {
        canCountdown = true;
    }
}
