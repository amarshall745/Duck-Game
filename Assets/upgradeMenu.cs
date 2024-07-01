using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeMenu : MonoBehaviour
{
    [Header("Increase/Decrease amount")]
    public float fireRate;
    public float fireRange;

    public float fireRangeLevel;
    public float maxFireRangeLevel;

    public MoneyManager mm;
    public GameManager gm;
    public gunStats gs;
    public PlayerController pc;

    void Start()
    { 

    }

    public void updae()
    {

    }

    public void DecreaseFireRate()
    {
        if (gs.decreaseFireRate(pc.activeGun.gameObject))
        {
            PlayerPrefs.SetFloat("fireRate", (PlayerPrefs.GetFloat("fireRate") + fireRate));
            Debug.Log("Fire Rate: " + PlayerPrefs.GetFloat("fireRate"));
        }
        else
        {
            Debug.Log("Can not decrease fire rate");
        }
    }

    public void IncreaseFireRate()
    {
        if (gs.increaseFireRate(pc.activeGun.gameObject))
        {
            float cost = mm.fireRateC * mm.gunDiscount;
            if (mm.money >= cost)
            {
                PlayerPrefs.SetFloat("fireRate", (PlayerPrefs.GetFloat("fireRate") - fireRate));
                Debug.Log("Fire Rate: " + PlayerPrefs.GetFloat("fireRate"));
                mm.money -= cost;
            }
            else
            {
                Debug.Log("Cant afford this upgrade");
            }
        }
        else
        {
            Debug.Log("Can not increase fire rate");
        }
    }

    public void DecreaseFireRange()
    {
        if (gs.decreaseFireRange(pc.activeGun.gameObject))
        {
            PlayerPrefs.SetFloat("fireRange", (PlayerPrefs.GetFloat("fireRange") - fireRange));
            Debug.Log("Fire range: " + PlayerPrefs.GetFloat("fireRange"));
        }
        else
        {
            Debug.Log("Can not decrease fire range");
        }
    }

    public void IncreaseFireRange()
    {
        if (gs.increaseFireRange(pc.activeGun.gameObject))
        {
                float cost = mm.fireRangeC * mm.gunDiscount;
                if (mm.money >= cost)
                {
                    PlayerPrefs.SetFloat("fireRange", (PlayerPrefs.GetFloat("fireRange") + fireRange));
                    Debug.Log("Fire Range: " + PlayerPrefs.GetFloat("fireRange"));
                    mm.money -= cost;
                }
                else { Debug.Log("Cant afford this upgrade"); }
        }
        else
        {
            Debug.Log("Can not increase fire range");
        }
    }

    public void AutoFireTrue()
    {
        PlayerPrefs.SetInt("autoFire", 1);
        Debug.Log("autoFire: " + PlayerPrefs.GetInt("autoFire"));
    }

    public void AutoFireFalse()
    {
        PlayerPrefs.SetInt("autoFire", 0);
        Debug.Log("autoFire: " + PlayerPrefs.GetInt("autoFire"));
    }

    public void SingleShot()
    {
        PlayerPrefs.SetInt("doubleShot", 0);
        Debug.Log("doubleShot: " + PlayerPrefs.GetInt("doubleShot"));
        gm.setSingleShot();
    }

    public void DoubleShot()
    {
        PlayerPrefs.SetInt("doubleShot", 1);
        Debug.Log("doubleShot: " + PlayerPrefs.GetInt("doubleShot"));
        gm.setDoubleShot();
    }

}
