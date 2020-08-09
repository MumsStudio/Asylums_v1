using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public string[] dialogLines;
    public int currentLine;

    //interaction behaviour
    public int interact;
    public Item item;
    public Info info;
    public bool triggered;
    private const int noInteract = 0;
    private const int takeItem = 1;
    private const int takeImportantItem = 2;
    private const int takeInfo = 3;

    private playercontroller thePlayer;

    private sfxManage sfxman;

    //image
    public Image DialogPortraitL;
    public Image DialogPortraitR;

    public Sprite[] imageL;
    public Sprite[] imageR;
    public Sprite blank;

    //enforced event control
    public DialogHolder dialogHolder;

    //post-dialog control
    public DialogHolder dialogAfterEvent;
    //event after enforced event code
    private playercontroller player;
    private const int DO_NOTHING = 0;
    private const int SAVE_GAME = 1;

    //Pop up
    public GameObject popup;

    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<playercontroller>();

        sfxman = FindObjectOfType<sfxManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (sfxman != null)
            {
                sfxman.buttonPress.Play();
            }
            currentLine++;
        }

        //finish dialog
        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            thePlayer.canMove = true;

            //if has interact option, do interact
            if (interact != 0 && !triggered)
            {
                switch (interact)
                {
                    case noInteract:
                        break;
                    //code 1 as take item
                    case takeItem:
                        //find backpack, and add item to back pack
                        GameObject.FindGameObjectWithTag("Player")
                            .GetComponentInChildren<Backpack>()
                            .addToBackpack(item.itemID);
                        break;
                    //code 2 as take important item
                    case takeImportantItem:
                        break;
                    //code 3 as take info
                    case takeInfo:
                        //put info into database, save if no duplicate
                        GameObject.FindGameObjectWithTag("Player")
                            .GetComponentInChildren<Backpack>()
                            .addInfo(info.infoId);
                        break;
             //       case npcInteractedEvent:
              //          GameObject.FindGameObjectWithTag("Player")
               //             .GetComponentInChildren<Backpack>()
              //             .addInfo(info.infoId);
               //         break;
                    default:
                        break;
                }
            }

            //if is an enforced event, destroy event after finish
            if (dialogHolder.isEnforcedEvent)
            {
                dialogHolder.GetComponent<DialogHolder>().disable = true;
            }

            // if save is needed
            if (dialogHolder.eventAfterEnforecedEvent != 0)
            {
                switch (dialogHolder.eventAfterEnforecedEvent)
                {
                    case DO_NOTHING: break;
                    //save game
                    case SAVE_GAME:
                        // instead of just call save function, call desicion box
                        GameObject desicion = GameObject.FindGameObjectWithTag("DecisionManager");
                        desicion.GetComponentInChildren<DecisionManage>().saveDecision();
                        break;
                }
            }
        }
        dText.text = dialogLines[currentLine];

        //add picture
        if (imageL[currentLine] == null) DialogPortraitL.sprite = blank;
        else DialogPortraitL.sprite = imageL[currentLine];
        if (imageR[currentLine] == null) DialogPortraitR.sprite = blank;
        else DialogPortraitR.sprite = imageR[currentLine];
    }

    public void ShowBox()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
