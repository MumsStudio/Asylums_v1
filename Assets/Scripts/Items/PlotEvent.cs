using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEvent")]
public class PlotEvent : ScriptableObject
{
    public string eventId;
    public string info;
    public string importency;
}