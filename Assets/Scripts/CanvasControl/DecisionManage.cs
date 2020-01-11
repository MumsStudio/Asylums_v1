using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionManage : MonoBehaviour {

    public GameObject box;
    public GameObject decisionDecription;
    public GameObject popup;
    //public GameObject applyBt;
    //public GameObject cancelBt;

    private bool confirmApply = false;
    private bool cancelDecision = false;
    private playercontroller player;
    private int choiceOption;   // 1 for save.

    private const int SAVE = 1;
    private GameObject canvas;


    // Use this for initialization
    void Start () {
        this.setActiveDecisionBox();
        this.canvas = GameObject.FindGameObjectWithTag("MainCanvas");
    }
	
	// set decision box active/deactive
    public void setActiveDecisionBox()
    {
        // TODO: add player controller stop/continue function needed
        this.box.SetActive(!this.box.activeSelf);
    }

    // applyBt set confirm stage
    public void confirmBtOnClick()
    {
        //Debug.Log("confirmed");
        // save function choice
        switch (choiceOption)
        {
            case SAVE:
                //Debug.Log("start saving");
                this.saveFunctionConfirmed();
                break;
        }
        setActiveDecisionBox();
    }

    // cancelBt set cancel stage
    public void cancelBtOnClick()
    {
        Debug.Log("canceled");
        setActiveDecisionBox();
        string msg = "Decision canceled.";
        this.popup.GetComponent<PopUpMsgController>().PopUpMsg(msg, 2f);
    }

    // save function called first to wake up decision manager
    public void saveDecision()
    {
        this.choiceOption = 1;
        this.decisionDecription.GetComponentInChildren<Text>().text = "Are you sure you want to save current process and overwrite the old one?";
        // TODO: change apply and cancel bt text

        // turn on canvas and decision box only
        canvas.SetActive(true);
        this.setActiveDecisionBox();

        if (confirmApply) {
            // TODO: confirm should call save process
            setActiveDecisionBox();

        }
        else if (cancelDecision) {
            // hide canvas
            confirmApply = false;
            cancelDecision = false;
        }
        
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
