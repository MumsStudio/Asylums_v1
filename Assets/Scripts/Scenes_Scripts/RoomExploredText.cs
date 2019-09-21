using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomExploredText : MonoBehaviour {
    private string[] temp;
    private string NOfRoom;
    public Backpack BP;
    public Text myText;
    //change the text to Backpack script's data
    public void changeText()
    {
        temp = BP.roomExplored.ToArray();
        NOfRoom = string.Join(",", temp);
        myText.text = NOfRoom;
    }
	
}
