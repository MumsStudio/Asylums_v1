using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    public playercontroller player;     //player
    //public Backpack backpack;         //will use player to load its child gameobject backpack
    //public Time playedTime;           //general info on time played
    public string sceneCode;            //witch map to load
    public Vector2 position;            //position on current map

    public SaveData(playercontroller player)
    {
        this.player = player;
        this.position.x = player.transform.position.x;
        this.position.y = player.transform.position.y;

        //load current scene to data which is gonna save
        //this.sceneCode = ;
    }
}
