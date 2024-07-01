using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunStats : MonoBehaviour
{
    [Header("Pistol Stats")]
    public float minFireRate;
    public float maxFireRate;
    public float minFireRange;
    public float maxFireRange;
    public bool autoFire;
    public bool doubleShot;

    public bool decreaseFireRate(GameObject gun)
    {
        if (gun.tag == "pistol")
        {
            if (PlayerPrefs.GetFloat("fireRate") < minFireRate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool increaseFireRate(GameObject gun)
    {
        if (gun.tag == "pistol")
        {
            if (PlayerPrefs.GetFloat("fireRate") > maxFireRate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool decreaseFireRange(GameObject gun)
    {
        if (gun.tag == "pistol")
        {
            if (PlayerPrefs.GetFloat("fireRange") > minFireRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool increaseFireRange(GameObject gun)
    {
        if (gun.tag == "pistol")
        {
            if (PlayerPrefs.GetFloat("fireRange") < maxFireRange)
            {
                return true;
            }
            else
            {
                Debug.Log("cant decrease " + PlayerPrefs.GetFloat("fireRange"));
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
