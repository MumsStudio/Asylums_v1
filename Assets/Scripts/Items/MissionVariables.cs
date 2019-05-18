using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission")]

public class MissionVariables : ScriptableObject
{
    public string missionID;
    public string description;
    public string nextMission;
   
}
