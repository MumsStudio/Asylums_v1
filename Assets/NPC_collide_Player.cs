using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_collide_Player : MonoBehaviour {

    public DialogHolder eventDialog;
    public NPCMovement Wooden;

    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        if (colli.gameObject.tag.Contains("Player"))
        {
            Wooden.speed = 0;
        }
    }
    
}
