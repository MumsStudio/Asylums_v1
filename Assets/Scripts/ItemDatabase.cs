using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<DatabaseItem> ItemList;
    //lists: Item IT,Infordb InD,Event ED.
    //     ; IT.id, IT.information
    //     ; search IT.id

   // public const string itemInitial = "item";
}
[System.Serializable]
public class  DatabaseItem : System.Object
{
    public int id;
    public Item item;    
}
[System.Serializable]
public class DatabaseInfordb : System.Object
{
    public DatabaseInfordb() { }
    public int id;
    public Info Infordb;
}
[System.Serializable]
public class DatabaseEvent : System.Object
{
    public DatabaseEvent() { }
    public int id;
    public PlotEvent Event;
}