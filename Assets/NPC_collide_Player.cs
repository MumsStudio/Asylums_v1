using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_collide_Player : MonoBehaviour {

    public DialogHolder eventDialog;
    public NPCMovement Wooden;
    public float tempValue;

    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            tempValue = Wooden.speed;
            Wooden.speed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D colli)
    {
        if (eventDialog.disable)
        {
            Wooden.speed = tempValue;
            Debug.Log("exit zone after enforced event");
            //call to awake next dialog
            //if (eventDialog.isEnforcedEvent && eventDialog.disable)
            //{
            //    //eventDialog.dialogAfterEvent.gameObject.SetActive(true);
           // }
        }
    }
}
