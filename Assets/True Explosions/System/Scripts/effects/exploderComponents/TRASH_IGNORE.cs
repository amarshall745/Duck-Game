/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadUp : MonoBehaviour
{
    public string[] commonPowerUps = new string[] { "RapidFire", "DoubleShot", "DoubleJump", "ExtraAmmo", "Grenade" };
    public string[] rarePowerUps = new string[] { "TurretDuck", "JetPack", "RocketLauncher", "AutoLock", "TempUnlimited", "Attacks" };
    public string[] epicPowerUps = new string[] { "Nuke", "DuckTank", "DuckTornado", "AirStrike", "BlackHole", "Teleport", "Drone" };


    //I can probaly remove the 3 string varaibels if you want, would just need to re-write stuff
    public int commonPowerUpInt;
    public string commonPowerUpString;
    public int rarePowerUpInt;
    public string rarePowerUpString;
    public int epicPowerUpInt;
    public string epicPowerUpString;

    private PowerUpManager powerUpManager;
    private bool waitingForInput = false;


    void Start()
    {
        PlayerPrefs.SetInt("doubleShot", 0);

        powerUpManager = GetComponent<PowerUpManager>();

        // Starting the Load Up Stuffz
        Debug.Log("     ========== WELCOME TO THE LOAD UP METHOD ==========\nCommon Power Up: RapidFire, DoubleShot, Ability1, Ability2, Ability3");
        InitializeRandomPowerUp();
        Debug.Log("Press Y to confirm or U to re-roll\nCurrent Power-Up: " + commonPowerUpString);
        waitingForInput = true;
    }

    void Update()
    {
        if (waitingForInput)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Power-Up Confirmed: " + commonPowerUpString);
                waitingForInput = false;
                commonPowerUpString = AddEffect(commonPowerUpString);
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("Re-rolling Power-Up");
                InitializeRandomPowerUp();
                Debug.Log("Press Y to confirm or U to re-roll\nCurrent Power-Up: " + commonPowerUpString);
                waitingForInput = true;
            }
        }
    }

    void InitializeRandomPowerUp()
    {
        commonPowerUpInt = Random.Range(0, commonPowerUps.Length);
        commonPowerUpString = commonPowerUps[commonPowerUpInt];
        Debug.Log("Initialized Power-Up: " + commonPowerUpString + " at index " + commonPowerUpInt);
    }

    string AddEffect(string powerUpName)
    {
        return powerUpName + "Effect";
    }
}
*/