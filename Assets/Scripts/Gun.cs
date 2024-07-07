using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject bullet;
    public GameObject autoBullet;
    public GameObject normalBullet;
    public GameObject rocketBullet;
    
    public bool autoDuck;
    public bool canAutoFire;
    public bool rocket;

    public int numOfDucks;
    [HideInInspector]
    public float fireCounter;

    public Transform firePoint, firePoint2;
    private Rigidbody rb;
    public float zoomAmount;

    void Start()
    {
        if (autoDuck)
        {
            Debug.Log("auto bullet");
            bullet = autoBullet;
        }
        else
        {
            Debug.Log("normal bullet");
            bullet = normalBullet;
        }

        if (rocket)
        {
            bullet = rocketBullet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }

    public void shoot()
    {
       // Debug.Log("Shoot");
        if (PlayerPrefs.GetInt("doubleShot") >= 1)
        {
            fire(Instantiate(bullet, firePoint2.position, firePoint2.rotation));
        }
        if (PlayerPrefs.GetInt("doubleShot") >= 0)
        {
            //Debug.Log("Fire bullet");
            fire(Instantiate(bullet, firePoint.position, firePoint.rotation));
        }

    }

    void fire(GameObject go)
    {
        rb  = go.GetComponent<Rigidbody>();

        if (rocket == true)
        {
            go.GetComponent<rocketController>().Countdown();
        }
        else
        {
            go.GetComponent<BulletController>().Countdown();
        }
        rb.velocity = go.transform.forward * PlayerPrefs.GetFloat("fireRange");
    }
}
 