using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoTurret : MonoBehaviour
{

    public LayerMask layerMask;
    private Vector3 hitPoint;

    public GameObject duck;
    public Transform firePoint;

    public bool sceneLaser;

    public float rotationSpeed;
    public float distance;
    public float firingSpeed;
    public float waitTime;

    private Rigidbody rb;
    private bool isCoolingDown = false;

    
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        RaycastHit hit;

        if (!isCoolingDown)
        {
            if (Physics.Raycast(origin, direction, out hit, distance, layerMask))
            {
              //  Debug.Log("Hit " + hit.collider.name);

                hitPoint = hit.point;

                if (sceneLaser)
                {
                    Debug.DrawLine(origin, hit.point, Color.red, 2f);
                }

                StartCoroutine(Cooldown());
                fire(Instantiate(duck, firePoint.position, firePoint.rotation));
                StartCoroutine(Cooldown());
            }
            else
            {
                if (sceneLaser)
                {
                    Debug.DrawLine(origin, origin + direction * distance, Color.red, 2f);
                }
                RotateObject();
            }
        }
    }

    void RotateObject()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }

    void fire(GameObject go)
    {
        rb = go.GetComponent<Rigidbody>();
        rb.velocity = go.transform.forward * firingSpeed;
    }

    IEnumerator Cooldown()
    {
        isCoolingDown = true;

        yield return new WaitForSeconds(waitTime);

        isCoolingDown = false;
    }

}
