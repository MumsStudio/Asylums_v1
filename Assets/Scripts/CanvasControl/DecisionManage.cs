using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionManage : MonoBehaviour {

    public GameObject box;
    public GameObject decisionDecription;
    //public GameObject applyBt;
    //public GameObject cancelBt;

    private bool confirmApply = false;
    private bool cancelDecision = false;

    // Use this for initialization
    void Start () {
        this.setActiveDecisionBox();
	}
	
	// set decision box active/deactive
    public void setActiveDecisionBox()
    {
        this.box.SetActive(!this.box.activeSelf);
    }

    // applyBt set confirm stage
    public bool confirmBtOnClick()
    {
        this.confirmApply = true;
        return this.confirmApply;
    }

    // cancelBt set cancel stage
    public bool cancelBtOnClick()
    {
        this.cancelDecision = true;
        return this.cancelDecision;
    }

    // save function
    public void saveDecision()
    {
        this.decisionDecription.GetComponentInChildren<Text>().text = "Are you sure you want to save current process and overwrite the old one?";

        if (confirmApply) {
            // TODO: confirm should call save process
        }
        else if (cancelDecision) {
            // hide canvas
            setActiveDecisionBox();
        }

        // reset boolean values
        this.cancelDecision = false;
        this.confirmApply = false;
    }
}
