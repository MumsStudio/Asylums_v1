using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour {
    public GameObject player;
    public GameObject room;

    void OnTriggerExit2D(Collider2D other)
    {
        var img = room.GetComponentInChildren<SpriteRenderer>();
        room.GetComponent<Room>().roomOn=false;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var img = room.GetComponentInChildren<SpriteRenderer>();
        room.GetComponent<Room>().roomOn = true;
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
    }
}
