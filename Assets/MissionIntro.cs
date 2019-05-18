using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionIntro : MonoBehaviour {
    
    public Text myText;
    public EnforcedEvent EEvent;
    public MissionVariables mv;
    //change the text to next mission
    public void changeText()
    {
        if(EEvent.jobdone == true){
            //Debug.Log("11111111111");
            myText.text = mv.nextMission;
        }
        

    }

}

