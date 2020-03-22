using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnforcedEvent : MonoBehaviour {

    //enforced event is called once player entered the trigger zone, and destroyed once done
    public GameObject ForceEventZone;
    public DialogHolder eventDialog;
    public GameObject WoodenDialog;
    public NPCMovement Wooden;
    private playercontroller player;
    public bool jobdone;

    void Start()
    {
        player = FindObjectOfType<playercontroller>();
    }
    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            Wooden.speed = 2;
            eventDialog.enforcedEventCalled = true;
            jobdone = true;
            player.canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D colli)
    {        
        if (eventDialog.disable)
        {
            player.canMove = true;
            WoodenDialog.SetActive(true);
            //Debug.Log("exit zone after enforced event");
            ForceEventZone.SetActive(false);
            
        }
    }
}
