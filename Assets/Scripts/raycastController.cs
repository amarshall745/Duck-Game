using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastController : MonoBehaviour
{
    public Transform gizmoPoint;
    public float eRange, placeRange;

    private GameObject hitGO;
    private Vector3 hitPoint = Vector3.zero;

    public GameObject spawnerGO, turretGO, autoTurretGO;
    public bool spawner, turret, autoTurret;
    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(gizmoPoint.transform.position, gizmoPoint.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100))
        {
            hitPoint = hit.point;
            hitGO = hit.transform.gameObject;

            float distance = Vector3.Distance(gameObject.transform.position, hit.point);
            
            if (Input.GetKeyDown("e"))
            {
                if (distance <= eRange)
                {
                    if((hitGO.GetComponent("controllableTurret") as controllableTurret) != null)
                    {
                        hitGO.GetComponent<controllableTurret>().mount(gameObject);
                    }
                }
            }


            if (Input.GetKeyDown("2"))
            {
                if (distance <= placeRange)
                {
                    if (spawner)
                    {
                        Instantiate(spawnerGO, hitPoint + new Vector3(0f, 1.5f, 0f), Quaternion.identity);
                    }

                    if (turret)
                    {
                        Instantiate(turretGO, hitPoint + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                    }

                    if (autoTurret)
                    {
                        Instantiate(autoTurretGO, hitPoint + new Vector3(0f, 1f, 0f), Quaternion.identity);
                    }
                }
            }

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitPoint, 0.2f);
    }
}
