using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSave")]
public class SaveData : ScriptableObject
{
    public playercontroller infoId;
    public Backpack backpack;
    public Time description;
}
