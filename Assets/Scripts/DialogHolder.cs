using System.Collections;
using UnityEngine;

public class DialogHolder : MonoBehaviour {
    //public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;
    //value to control access
    public GameObject interact;

    // Use this for initialization
    public bool inzone = false;

    void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (inzone && Input.GetKeyUp(KeyCode.Space))
        {
            if (!dMAn.dialogActive)
            {
                dMAn.dialogLines = dialogueLines;
                dMAn.currentLine = 0;

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
