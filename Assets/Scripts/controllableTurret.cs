using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllableTurret : MonoBehaviour
{
    private Vector3 playerLocation;
    private Transform childTransform;
    public Transform barrelTransform;
    private Vector3 childPosition;

    public float fireCounter;
    public float fireRate;
    public float fireSpeed;
    public Transform firePoint;

    private Rigidbody rb;
    public GameObject bullet;

    private bool mounted;

    void Start()
    {
        barrelTransform = transform.Find("barrel");
    }

    void Update()
    {
        if (mounted)
        {
            if (fireCounter > 0)
            {
                fireCounter -= Time.deltaTime;
            }

            if (Input.GetMouseButtonDown(0) && fireCounter <= 0)
            {
                fire(Instantiate(bullet, firePoint.position, firePoint.rotation));
                fireCounter = fireRate;
            }
        }
    }

    public void mount(GameObject player)
    {
        Debug.Log("Mount turret" + player);
        playerLocation = player.transform.position;
        childTransform = transform.Find("seat");
        childPosition = childTransform.position;
        player.GetComponent<PlayerController>().onTurret();
        player.transform.position = childPosition;

        transform.parent = player.transform;
        transform.localRotation = Quaternion.identity;

        barrelTransform.parent = player.GetComponent<PlayerController>().camera.transform;

        bullet = player.GetComponent<PlayerController>().activeGun.normalBullet;

        mounted = true;

    }

    void fire(GameObject go)
    {
        rb = go.GetComponent<Rigidbody>();
        go.GetComponent<BulletController>().Countdown();
        rb.velocity = go.transform.forward * fireSpeed;
    }
}
