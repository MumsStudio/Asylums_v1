using System.Collections;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

    private DialogueManager dMAn;

    public string[] dialogueLines;
    //value to control access
    public GameObject interact;

    // Use this for initialization
    public bool inzone = false;
    //image
    public Sprite[] DialogPortraitL;
    public Sprite[] DialogPortraitR;

    //for enforced event control purpose
    public bool isEnforcedEvent;
    public bool enforcedEventCalled;

    void Start() {
        dMAn = FindObjectOfType<DialogueManager>();
        enforcedEventCalled = false;
    }

    // Update is called once per frame
    void Update() {
        if ((inzone && Input.GetKeyUp(KeyCode.Space)) || (enforcedEventCalled && isEnforcedEvent))
        {
            if (!dMAn.dialogActive)
            {
                dMAn.dialogLines = dialogueLines;
                dMAn.currentLine = 0;

                //enforced event control
                dMAn.dialogHolder = this;

                //interaction control
                if (interact != null)
                {
                    dMAn.interact = interact.GetComponent<Interact>().interact;
                    if (dMAn.interact != 0)
                    {
                        dMAn.item = interact.GetComponent<Interact>().item;
                        dMAn.info = interact.GetComponent<Interact>().info;
                        dMAn.triggered = interact.GetComponent<Interact>().triggered;
                        interact.GetComponent<Interact>().triggered=true;
                    }
                }

                dMAn.ShowBox();
                dMAn.imageL = DialogPortraitL;
                dMAn.imageR = DialogPortraitR;
                inzone = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inzone = false;
        }
    }
}
