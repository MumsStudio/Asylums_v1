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
    public List<int> eventsDone;
    public int namelessEvent;

    void Start()
    {
        eventsDone = carryDataBetwScreen.Instance.eventsDone;
        if (eventsDone.Contains(namelessEvent))
        {
            GameObject namesless = transform.parent.parent.gameObject;
            Destroy(namesless);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D colli)
    {
        if (eventsDone.Contains(namelessEvent))
        {
            return;
        }

        if (isTriggered) {
            return;
        }

        playableDirector.Play();
        if (dialogHolder != null)
        {
            StartCoroutine(StartPlotDisplay());

            isTriggered = true;
            dialogHolder.namelessInteracted = true;
            eventsDone.Add(namelessEvent);
        }
    }



    private IEnumerator StartPlotDisplay()
    {
        yield return new WaitForSeconds(delaytime);
        dialogHolder.enforcedEventCalled = true;
    }
}
