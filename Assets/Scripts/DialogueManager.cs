﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;
    private playercontroller thePlayer;
    // Use this for initialization
    void Start () {
        
        thePlayer = FindObjectOfType<playercontroller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }
        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
            thePlayer.canMove = true;
        }
        Debug.Log(dialogLines.Length);

        dText.text = dialogLines[currentLine];
    }

    public void ShowBox()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
       
    }
}
