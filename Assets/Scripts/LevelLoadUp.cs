using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadUp : MonoBehaviour
{
    //These stats will be moved to a diffrent script soon :O
    //Common stats - I can probably remove the "string commonPowerUpString;" just need to re-write code
    public int commonPowerUpInt;
    public string commonPowerUpString;
    public string[] commonPowerUpsName = new string[] { "RapidFire", "DoubleShot", "DoubleJump", "ExtraAmmo", "Grenade"};
    public int[] commonPowerUpLevel = new int[] { 1, 1, 1, 1, 1 };  //NEEDS TO BE A PLAYER PREFF
    public string[] commonPowerUpsDescription = new string[] { 
        "RapidFire: **Insert Description Here**",
        "DoubleShot: **Insert Description Here**",
        "DoubleJump: **Insert Description Here**",
        "ExtraAmmo: **Insert Description Here**",
        "Grenade: **Insert Description Here**"};
    public int[] commonPowerUpsDuration = new int[] { 10, 9, 2, 4, 7 };
    public int[] commonPowerUpsCoolDown = new int[] { 15, 12, 6, 9, 12 };
    //shop stats
    public int[] commonPowerUplBaseCost = new int[] { 15, 12, 6, 9, 12 };
    //upgrades
    public string[] commonPowerUpsLevel2 = new string[] {
        "RapidFire: **Insert Upgrade Description Here**",
        "DoubleShot: **Insert Upgrade Description Here**",
        "DoubleJump: **Insert Upgrade Description Here**",
        "ExtraAmmo: **Insert Upgrade Description Here**",
        "Grenade: **Insert Upgrade Description Here**"};

    public int[] commonPowerUpsDescriptionLevel2 = new int[] { 15, 12, 6, 9, 12 };



    //Rare & epic stats - not functional ATM :O
    public string[] rarePowerUps = new string[] { "TurretDuck", "JetPack", "RocketLauncher", "AutoLock", "TempUnlimited", "Attacks" };
    public string[] epicPowerUps = new string[] { "Nuke", "DuckTank", "DuckTornado", "AirStrike", "BlackHole", "Teleport", "Drone" };
    public int rarePowerUpInt;
    public string rarePowerUpString;
    public int epicPowerUpInt;
    public string epicPowerUpString;


    private int[] selectedPowerUpIndices = new int[3];
    private bool waitingForInput = false;

    private PowerUpManager powerUpManager;

    void Start()
    {
        powerUpManager = GetComponent<PowerUpManager>();

        // Starting the Load Up Stuff
        Debug.Log("========== WELCOME TO THE LOAD UP METHOD ==========\nCommon Power Up: RapidFire, DoubleJump, ExtraAmmo, Grenade");
        InitializeRandomPowerUps();
        waitingForInput = true;
    }

    void Update()
    {
        if (waitingForInput)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                commonPowerUpInt = selectedPowerUpIndices[0];
                ConfirmPowerUp(commonPowerUpInt);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                commonPowerUpInt = selectedPowerUpIndices[1];
                ConfirmPowerUp(commonPowerUpInt);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                commonPowerUpInt = selectedPowerUpIndices[2];
                ConfirmPowerUp(commonPowerUpInt);
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("Re-rolling Power-Up");
                InitializeRandomPowerUps();
                waitingForInput = true;
            }
        }
    }

    void InitializeRandomPowerUps()
    {
        List<int> indices = new List<int>();
        while (indices.Count < 3)
        {
            int index = Random.Range(0, commonPowerUpsName.Length);
            if (!indices.Contains(index))
            {
                indices.Add(index);
            }
        }

        selectedPowerUpIndices[0] = indices[0];
        selectedPowerUpIndices[1] = indices[1];
        selectedPowerUpIndices[2] = indices[2];

        Debug.Log("Choose a Power-Up: \n1: " + commonPowerUpsName[selectedPowerUpIndices[0]] + "\t2: " + commonPowerUpsName[selectedPowerUpIndices[1]] + "\t3: " + commonPowerUpsName[selectedPowerUpIndices[2]] + "\t\tPress U to re-roll");
    }

    void ConfirmPowerUp(int i)
    {
        commonPowerUpString = commonPowerUpsName[i];
        Debug.Log("Power-Up Confirmed: " + commonPowerUpString);
        waitingForInput = false;
        commonPowerUpString = AddEffect(commonPowerUpString);
        // Continue with the game logic here
    }

    string AddEffect(string powerUpName)
    {
        return powerUpName + "Effect";
    }
}
