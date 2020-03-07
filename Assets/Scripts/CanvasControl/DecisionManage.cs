using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionManage : MonoBehaviour
{

    public GameObject box;
    public GameObject decisionDecription;
    public GameObject popup;
    public GameObject opt1Bt;
    public GameObject opt2Bt;
    public GameObject opt3Bt;

    //private bool confirmApply = false;
    //private bool cancelDecision = false;
    private playercontroller player;
    private int choiceOption;   // 1 for save.

    private const int SAVE = 1;
    private GameObject canvas;

    public const int OPTION1 = 1;
    public const int OPTION2 = 2;
    public const int OPTION3 = 2;


    // Use this for initialization
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.player = player.GetComponentInChildren<playercontroller>();
        // add listener to the buttons
        opt1Bt.GetComponentInChildren<Button>().onClick.AddListener(() => option1BtOnClick());
        opt2Bt.GetComponentInChildren<Button>().onClick.AddListener(() => option2BtOnClick());
        opt3Bt.GetComponentInChildren<Button>().onClick.AddListener(() => option3BtOnClick());

        setActiveDecisionBox();

    }

    // set decision box active/deactive
    public void setActiveDecisionBox()
    {
        Debug.Log(box.activeSelf);
        box.SetActive(!box.activeSelf);
        // player controller stop/continue during desicion making
        player.canMove = !box.activeSelf;
    }

    // option1 for desicion
    public void option1BtOnClick()
    {
        Debug.Log("opt1");
        // save function choice
        switch (choiceOption)
        {
            case SAVE:
                //Debug.Log("start saving");
                this.saveFunctionConfirmed();
                break;
        }
        Debug.Log("close dbox by op1 bt");
        setActiveDecisionBox();
    }

    // option2
    public void option2BtOnClick()
    {
        Debug.Log("opt2");
        // save function choice
        switch (choiceOption)
        {
            // for saving, optioin2 should be hidden
            case SAVE:
                break;
        }
        Debug.Log("close dbox by op2 bt");
        setActiveDecisionBox();
    }

    // option3
    public void option3BtOnClick()
    {
        // save function choice
        switch (choiceOption)
        {
            case SAVE:
                //Debug.Log("start saving");
                this.saveFunctionConfirmed();
                string msg = "Save canceled.";
                this.popup.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
                break;
        }
        Debug.Log("close dbox by op3 bt");
        setActiveDecisionBox();
    }

    // save function called first to wake up decision manager
    public void saveDecision()
    {
        this.choiceOption = 1;
        this.decisionDecription.GetComponentInChildren<Text>().text = "Are you sure you want to save current process and overwrite the old one?";

        // set option bt avtivition
        this.opt1Bt.SetActive(true);
        this.opt2Bt.SetActive(false);
        this.opt3Bt.SetActive(true);
        // change option bt text
        this.opt1Bt.GetComponentInChildren<Text>().text = "Yes";
        this.opt3Bt.GetComponentInChildren<Text>().text = "No";

        // turn on canvas and decision box only
        canvas.SetActive(true);
        this.setActiveDecisionBox();
    }

    // save function confirmed
    private void saveFunctionConfirmed()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
        player.PlayerSaveData();
        string msg = "Wooden has wrote a note for the time.";
        this.popup.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
    }
}
