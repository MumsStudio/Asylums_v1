using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem")]
public class Item: ScriptableObject
{

    public string itemID;
    public string itemName;
    public string description;
    //0 as normal item, 1 as important item
    public int itemClass=0;

    public Sprite itemImage;

}
