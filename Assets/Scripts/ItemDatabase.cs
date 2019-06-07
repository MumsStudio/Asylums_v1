using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<DatabaseItem> itemDB;
    public List<DatabaseInfordb> infoDB;
    public List<DatabaseEvent> eventDB;    

    public DatabaseItem findItemById(int i)
    {
        foreach (DatabaseItem it in itemDB)
        {
            if (it.id == i) return it;
        }
        Debug.Log("Item with id not found");
        return null;
    }
    public DatabaseInfordb findInfoById(int i)
    {
        foreach (DatabaseInfordb it in infoDB)
        {
            if (it.id == i) return it;
        }
        Debug.Log("Information with id not found");
        return null;
    }
    public DatabaseEvent findEventById(int i)
    {
        foreach (DatabaseEvent it in eventDB)
        {
            if (it.id == i) return it;
        }
        Debug.Log("Event with id not found");
        return null;
    }
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