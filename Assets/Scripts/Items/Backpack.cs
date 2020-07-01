using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Backpack : MonoBehaviour
{
    public List<int> items;
    public List<int> infoDB;
    public List<int> eventsDone;
    public List<string> roomExplored;
    public GameObject pop;

    public Text txt;
    public Text miss;

    //load itmes from globalObejct first 
    void Start()
    {

        items = carryDataBetwScreen.Instance.items;
        infoDB = carryDataBetwScreen.Instance.infoDB;
        eventsDone = carryDataBetwScreen.Instance.eventsDone;
        roomExplored = carryDataBetwScreen.Instance.roomExplored;
    }

    //add item into backpack
    public void addToBackpack(int item)
    {
        items.Add(item);

        //popup msg needed
        GameObject DB = GameObject.FindGameObjectWithTag("DB");
        string msg = DB.GetComponent<ItemDatabase>().findItemById(item).item.name+" has been added to the backpack.";
        pop.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);

        //txt.text = "item...";
    }

    public void removeFromBackpack(int item)
    {
        //remove item from list
        items.Remove(item);

        //popup msg needed
        GameObject DB = GameObject.FindGameObjectWithTag("DB");
        string msg = DB.GetComponent<ItemDatabase>().findItemById(item).item.name + " has been removed from the backpack.";
        pop.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
    }

    public void addInfo(int info)
    {        
        GameObject DB = GameObject.FindGameObjectWithTag("DB");
        //boolean to prevent duplication
        bool dup = false;

        Debug.Log(DB);
        for (int i = 0; i < infoDB.Count; i++)
        {
            if (infoDB[i] == info){
                dup = true;
                break;
            }
        }
        if (!dup)
        {
            infoDB.Add(info);
            //popup msg
            string msg = "Information has been recorded.";
            Debug.Log(msg);
            pop.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);

            //miss.text = "miss...";
        }  
    }

    public void addRoomExplored(string roomId)
    {
        if (!IfRoomExplored(roomId))
        {
            this.roomExplored.Add(roomId);
        }        
    }

    public bool IfRoomExplored(string roomId)
    {
        foreach(string rom in roomExplored)
        {
            if (rom == roomId) return true;
        }
        return false;
    }

    //Save data to global control
    public void SavePlayer()
    {
        carryDataBetwScreen.Instance.items = items;
        carryDataBetwScreen.Instance.infoDB = infoDB;
        carryDataBetwScreen.Instance.eventsDone = eventsDone;
        carryDataBetwScreen.Instance.roomExplored = roomExplored;
    }

}
