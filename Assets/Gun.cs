using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;

    public bool canAutoFire;
    public int numOfDucks;
    [HideInInspector]
    public float fireCounter;

    public Transform firePoint, firePoint2;
    private Rigidbody rb;
    public float zoomAmount;

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
        rb.velocity = go.transform.forward * PlayerPrefs.GetFloat("fireRange");
    }
}
