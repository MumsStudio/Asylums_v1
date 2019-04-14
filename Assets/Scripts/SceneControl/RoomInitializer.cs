using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInitializer : MonoBehaviour {
    public List<GameObject> rooms;

    public void RoomInitialize()
    {
        foreach(GameObject room in rooms)
        {
            room.GetComponentInChildren<RoomChanger>().InitializeRoomState();
        }
    }
}
