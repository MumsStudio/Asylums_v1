using System.Collections;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

    private DialogueManager dMAn;
    public string[] dialogueLines;
    public bool disable;

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

    //for post-conversation controll
    public DialogHolder dialogAfterEvent;
    //event after enforced event code
    public int eventAfterEnforecedEvent;
    private const int doNothing = 0;
    private const int saveGame = 1;

    void Start() {
        dMAn = FindObjectOfType<DialogueManager>();
        enforcedEventCalled = false;
    }

    // Update is called once per frame
    void Update() {

        //if disabled, do nothing besides close dialog ui
        if (disable) { }
        else if ((inzone && Input.GetKeyUp(KeyCode.Space))
            || (enforcedEventCalled && isEnforcedEvent))
        {
            if (!dMAn.dialogActive)
            {
                dMAn.dialogLines = dialogueLines;
                dMAn.currentLine = 0;

                //enforced event control
                dMAn.dialogHolder = this;
                dMAn.dialogAfterEvent = this.dialogAfterEvent;

                //interaction control
                if (interact != null)
                {
                    dMAn.interact = interact.GetComponent<Interact>().interact;
                    if (dMAn.interact != 0)
                    {
                        dMAn.item = interact.GetComponent<Interact>().item;
                        dMAn.info = interact.GetComponent<Interact>().info;
                        dMAn.triggered = interact.GetComponent<Interact>().triggered;
                        interact.GetComponent<Interact>().triggered = true;

                        Destroy(interact.GetComponent<Interact>().ui);
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
            if (disable)
            {
                // post-dialog trigger
                dialogAfterEvent.gameObject.SetActive(true);
            }                
        }
    }
}
