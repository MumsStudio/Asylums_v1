using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforcedEvent : MonoBehaviour {

    //enforced event is called once player entered the trigger zone, and destroyed once done
    public DialogHolder eventDialog;
    public NPCMovement Wooden;
    public playercontroller player;
    public bool jobdone;

    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            Wooden.speed = 2;
            eventDialog.enforcedEventCalled = true;
            jobdone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D colli)
    {        
        if (eventDialog.disable)
        {
            Wooden.speed = 2;
            Debug.Log("exit zone after enforced event");
            //call to awake next dialog
            if (eventDialog.isEnforcedEvent && eventDialog.disable)
            {
                //eventDialog.dialogAfterEvent.gameObject.SetActive(true);
            }                
        }
    }
}
