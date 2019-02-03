using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {
    //value to control interac option
    //0 as no interact, 1 as take item, 2 as take important item, 3 as take info
    public int interact;
    public Item item;
    public Info info;
    public GameObject popup;
    public string msg;
    public int eventNum;

    public void PopUp()
    {
        popup.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
    }
}
