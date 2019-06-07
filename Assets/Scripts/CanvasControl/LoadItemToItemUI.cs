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
        GameObject DB = GameObject.FindGameObjectWithTag("DB");

        foreach (int item in backpack.GetComponentInChildren<Backpack>().items)
        {
            listOfItem += " " + DB.GetComponent<ItemDatabase>().findItemById(item).item.name;
        }
        itemText.GetComponentInChildren<Text>().text = listOfItem;
	}
}
