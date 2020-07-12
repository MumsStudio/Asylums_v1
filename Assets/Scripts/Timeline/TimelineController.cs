using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public DialogHolder dialogHolder;
    public int delaytime;

    private void OnTriggerEnter2D(Collider2D colli)
    {
        playableDirector.Play();
        if (dialogHolder != null)
        {
            StartCoroutine(StartPlotDisplay());
        }
    }

    private IEnumerator StartPlotDisplay()
    {
        yield return new WaitForSeconds(delaytime);
        dialogHolder.enforcedEventCalled = true;
    }
}
