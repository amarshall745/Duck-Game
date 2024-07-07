using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Keeps track of stats in each level.
/// 
/// This file should be added to each level and no data 
/// from it should be carried over, however it will have 
/// some checks againsts the player HighScoreStates
/// 
/// It keeps tracks of things such as 
/// - Points gained                     =   used for abilites
/// - Mobs killed                       =   player high scores
/// - time taken to complete level      =   Can use this to track cooldowns 
/// - distanced moved?                  =   optional
/// 
/// </summary>
public class LevelStats : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("autoFire", 0);
        PlayerPrefs.SetInt("doubleShot", 0);
    }


    void Update()
    {
        
    }
}
