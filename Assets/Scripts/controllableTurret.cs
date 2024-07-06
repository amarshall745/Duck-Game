using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllableTurret : MonoBehaviour
{
    private Vector3 playerLocation;
    private Transform seatTransform;
    private Vector3 seatPosition;
    private Transform barrelTransform;
    private GameObject player;

    public bool autoFire;
    public int numberOfShots;
    public float fireCounter;
    public float fireRate;
    public float fireSpeed;
    public Transform firePoint;

    private Rigidbody rb;
    private GameObject bullet;

    private bool mounted = false;

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

            if (Input.GetMouseButtonDown(0) && fireCounter <= 0 && numberOfShots > 0)
            {
                fire(Instantiate(bullet, firePoint.position, firePoint.rotation));
                fireCounter = fireRate;
            }

            if (Input.GetMouseButton(0) && autoFire && numberOfShots > 0)
            {
                if (fireCounter <= 0)
                {
                    fire(Instantiate(bullet, firePoint.position, firePoint.rotation));
                    fireCounter = fireRate;
                }
            }

            if (Input.GetKeyDown("e"))
            {
                unmount();
            }
        }
    }

    public void mount(GameObject playerGO)
    {
        player = playerGO;

        Debug.Log("Mount turret" + player);
        playerLocation = player.transform.position;
        seatTransform = transform.Find("seat");
        seatPosition = seatTransform.position;
        player.GetComponent<PlayerController>().onTurret();
        player.transform.position = seatPosition;

        transform.parent = player.transform;
        transform.localRotation = Quaternion.identity;

        barrelTransform.parent = player.GetComponent<PlayerController>().camera.transform;

        bullet = player.GetComponent<PlayerController>().activeGun.normalBullet;

        mounted = true;

    }

    public void unmount()
    {
        Debug.Log("Unmount");
        mounted = false;

        barrelTransform.SetParent(gameObject.transform);
        gameObject.transform.SetParent(null);

        player.transform.position = playerLocation;
        player.GetComponent<PlayerController>().offTurret();
    }

    void fire(GameObject go)
    {
        numberOfShots--;
        rb = go.GetComponent<Rigidbody>();
        go.GetComponent<BulletController>().Countdown();
        rb.velocity = go.transform.forward * fireSpeed;
    }
}
