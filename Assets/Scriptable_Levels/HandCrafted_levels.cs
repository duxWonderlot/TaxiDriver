using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "HandCrafted/newLevels", order = 1)]
public class HandCrafted_levels : ScriptableObject
{
    //Container of objects for each level in the game
    public GameObject[] Feeding_Values_Obs;
    public GameObject[] Emplty_obs_Spawn;
    public int Vechicals_count,Passenger_count;
    //Color codes are used for Knowing the specific level
    public Color value;
    
}
