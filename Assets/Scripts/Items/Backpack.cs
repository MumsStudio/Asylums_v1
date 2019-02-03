using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public List<Item> items;
    public List<Info> infoDB;

    //add item into backpack
    public void addToBackpack(Item item)
    {
        items.Add(item);
        //popup msg needed
    }

    public void removeFromBackpack(Item item)
    {        
    }

    public void addInfo(Info info)
    {
        if (info != null)
        {
            bool dup = false;
                for(int i = 0; i < infoDB.Count; i++)
                {
                    if (infoDB[i].infoId == info.infoId){
                        dup = true;
                        break;
                    }
                }
                if (!dup) infoDB.Add(info);
        }        
    }
}
