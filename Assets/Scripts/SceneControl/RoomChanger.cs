using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour {
    public GameObject player;
    public GameObject room;

    private void Start()
    {
        InitializeRoomState();        
    }

    public void InitializeRoomState()
    {
        float colr = 0f;
        if (player.GetComponentInChildren<Backpack>().IfRoomExplored(room.GetComponent<Room>().roomId))
        {
            colr = 0.3f;
            Debug.Log(this.name + " has been explored.");
        }
        SpriteRenderer[] objs = room.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].color = new Color(objs[i].color.r, objs[i].color.g, objs[i].color.b, colr);
        }
        room.GetComponent<Room>().roomOn = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.Equals(player.GetComponent<Collider2D>()))
        {
            float colr = 0f;
            if (room.GetComponent<Room>().roomDiscovered)
            {
                colr =0.3f;
            }
            SpriteRenderer[] objs = room.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].color = new Color(objs[i].color.r, objs[i].color.g, objs[i].color.b, colr);
            }
            room.GetComponent<Room>().roomOn=false;
        }            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.Equals(player.GetComponent<Collider2D>()))
        {
            room.GetComponent<Room>().roomDiscovered = true;
            SpriteRenderer[] objs = room.GetComponentsInChildren<SpriteRenderer>();
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].color = new Color(objs[i].color.r, objs[i].color.g, objs[i].color.b, 1f);
            }
            room.GetComponent<Room>().roomOn = true;
            player.GetComponentInChildren<Backpack>().addRoomExplored(room.GetComponent<Room>().roomId);
        }       
    }
}
