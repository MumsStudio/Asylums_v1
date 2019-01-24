using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public List<Item> items;

    //add item into backpack
    public void addToBackpack(Item item)
    {
        items.Add(item);
        //popup msg needed
    }

    public void removeFromBackpack(Item item)
    {        
    }
}
