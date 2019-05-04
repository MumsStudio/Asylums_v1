using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforcedEvent : MonoBehaviour {

    //enforced event is called once player entered the trigger zone, and destroyed once done
    public DialogHolder eventDialog;
    public bool jobdone;
    
    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            Debug.Log("Player in desnated area");
            eventDialog.enforcedEventCalled = true;
            jobdone = true;
        }
    }
}
