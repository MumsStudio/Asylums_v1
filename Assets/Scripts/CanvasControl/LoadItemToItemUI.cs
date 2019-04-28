using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadItemToItemUI : MonoBehaviour {
    public GameObject backpack;
    public GameObject itemText;
    	
	// Update is called once per frame
	public void UpdateItemTextBox () {
        string listOfItem = "";
        foreach(Item item in backpack.GetComponentInChildren<Backpack>().items)
        {
            listOfItem += " " + item.itemName;
        }
        itemText.GetComponentInChildren<Text>().text = listOfItem;
	}
}
