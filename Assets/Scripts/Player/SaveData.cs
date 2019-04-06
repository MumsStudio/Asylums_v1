using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public Position position;
    public List<Item> items;
    public List<Info> infoDB;
    public List<PlotEvent> eventsDone;
    public List<string> roomExplored;    
}

[System.Serializable]
public class Position
{
    public float x;
    public float y;
}