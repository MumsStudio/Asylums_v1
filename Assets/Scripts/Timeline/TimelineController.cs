using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public DialogHolder dialogHolder;
    public int delaytime;
    public bool isTriggered;

    private void OnTriggerEnter2D(Collider2D colli)
    {


        if (isTriggered) {
            return;
        }

        playableDirector.Play();
        if (dialogHolder != null)
        {
            StartCoroutine(StartPlotDisplay());

            isTriggered = true;
            dialogHolder.namelessInteracted = true;
        }
    }

    private IEnumerator StartPlotDisplay()
    {
        yield return new WaitForSeconds(delaytime);
        dialogHolder.enforcedEventCalled = true;
    }
}
