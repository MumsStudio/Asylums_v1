using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour {
    public GameObject player;
    public GameObject room;

    void OnTriggerExit2D(Collider2D other)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer[] objs = room.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].color = new Color(objs[i].color.r, objs[i].color.g, objs[i].color.b, 1f);
            //Debug.Log(objs[i].color);
        }
        room.GetComponent<Room>().roomOn = true;
    }
}
