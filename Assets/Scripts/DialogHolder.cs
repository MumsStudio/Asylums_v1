using System.Collections;
using UnityEngine;

public class DialogHolder : MonoBehaviour {
    //public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;
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
