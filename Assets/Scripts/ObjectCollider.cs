using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public GameObject explosion;
    public bool canDie;

    private void OnTriggerEnter(Collider other)
    {
        int layerMask = other.gameObject.layer;
        //Debug.Log("BOOM");
        if (layerMask == 6)
        {
            blowUp(other.gameObject);
        }
    }

    private void blowUp(GameObject other)
    {
        Destroy(other);
        if (canDie)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }

        Instantiate(explosion, transform.position, transform.rotation);
    }
}
