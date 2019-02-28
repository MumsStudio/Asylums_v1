using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public List<Item> items;
    public List<Info> infoDB;
    public List<PlotEvent> eventsDone;
    public GameObject pop;

    //add item into backpack
    public void addToBackpack(Item item)
    {
        items.Add(item);

        //popup msg needed
        string msg = item.name+"已被加入背包。";
        pop.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
    }

    public void removeFromBackpack(Item item)
    {
        //remove item from list

        //popup msg needed
        string msg = item.name + "已从背包中移除。";
        pop.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
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
            if (!dup)
            {
                infoDB.Add(info);
                //popup msg
                string msg = "信息已被记入。";
                pop.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
            }
        }        
    }
}
