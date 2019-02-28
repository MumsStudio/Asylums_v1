using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSave")]
public class SaveData : ScriptableObject
{
    public playercontroller player;     //player
    //public Backpack backpack;         //will use player to load its child gameobject backpack
    public Time playedTime;             //general info on time played
    public string sceneCode;            //witch map to load
    public Vector2 position;            //position on current map
}
