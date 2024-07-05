using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadUp : MonoBehaviour
{
    public string[] commonPowerUps = new string[]{ "RapidFire", "DoubleShot", "DoubleJump", "ExtraAmmo", "Grenade" };
    public string[] rarePowerUps = new string[] { "TurretDuck", "JetPack", "RocketLauncher", "AutoLock", "TempUnlimited", "Attacks" };
    public string[] epicPowerUps = new string[] { "Nuke", "DuckTank", "DuckTornado", "AirStrike", "BlackHole", "Teleport", "Drone" };
    
    public int commonPowerUpInt;
    public string commonPowerUpString;

    private PowerUpManager powerUpManager;
    private bool waitingForInput = false;

    void Start()
    {
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

                // Continue with the game logic here
                string powerUpWithEffect = AddEffect(commonPowerUpString);
                Debug.Log("Selected Power-Up with Effect: " + powerUpWithEffect);
                powerUpManager.ActivatePowerUpEffect(powerUpWithEffect);
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
