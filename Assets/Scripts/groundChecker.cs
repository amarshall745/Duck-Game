using AnythingWorld.Behaviour;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //Debug.Log("On");
            gameObject.GetComponent<RandomMovement>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //Debug.Log("Off");
            gameObject.GetComponent<RandomMovement>().enabled = false;
            gameObject.GetComponent<RandomMovement>().start();
        }
    }
}
