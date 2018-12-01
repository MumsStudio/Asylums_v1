using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRoom")]
public class Room : ScriptableObject {
    public string roomId;
    public GameObject roomObj;
    public bool roomOn;
}
