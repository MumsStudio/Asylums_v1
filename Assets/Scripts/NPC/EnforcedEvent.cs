using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EnforcedEvent : MonoBehaviour {

    //enforced event is called once player entered the trigger zone, and destroyed once done
    public GameObject ForceEventZone;
    public DialogHolder eventDialog;
    public GameObject WoodenDialog;
    public NPCMovement Wooden;
    private playercontroller player;
    public bool jobdone;

    public int delaytime;
    public PlayableDirector playableDirector;

    void Start()
    {
        player = FindObjectOfType<playercontroller>();
    }

    private void OnTriggerEnter2D(Collider2D colli)
    {
        //if collid with player start display dialog
        /*if (colli.gameObject.tag.Contains("Player"))
        {
            Wooden.speed = 2;
            eventDialog.enforcedEventCalled = true;
            jobdone = true;
            player.canMove = false;
        }*/

        if (colli.gameObject.tag.Contains("Player"))
        {
            playableDirector.Play();
            if (eventDialog != null)
            {
                StartCoroutine(StartPlotDisplay());
            }
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

    private IEnumerator StartPlotDisplay()
    {
        yield return new WaitForSeconds(delaytime);
        eventDialog.enforcedEventCalled = true;
        eventDialog.isEnforcedEvent = true;
    }
}
