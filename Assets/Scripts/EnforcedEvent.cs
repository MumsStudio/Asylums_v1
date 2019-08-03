using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforcedEvent : MonoBehaviour {

    //enforced event is called once player entered the trigger zone, and destroyed once done
    public DialogHolder eventDialog;
    public NPCMovement Wooden;
    public float tempValue;
    public bool jobdone;

    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            eventDialog.enforcedEventCalled = true;
            tempValue = Wooden.speed;
            Wooden.speed = 0;
            jobdone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D colli)
    {        
        if (eventDialog.disable)
        {
            Wooden.speed = tempValue;
            Debug.Log("exit zone after enforced event");
            //call to awake next dialog
            if (eventDialog.isEnforcedEvent && eventDialog.disable)
            {
                //eventDialog.dialogAfterEvent.gameObject.SetActive(true);
            }                
        }
    }
}
