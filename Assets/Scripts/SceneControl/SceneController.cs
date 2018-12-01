using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevel")]
public class SceneController : ScriptableObject {
    public string levelId;
    public List<Room> roomsInLevel;
}
