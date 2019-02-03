﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;
    public string[] dialogLines;
    public int currentLine;

    //interaction behaviour
    public int interact;
    public Item item;
    public Info info;

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

            //if has interact option, do interact
            if (interact!=0)
            {
                switch (interact)
                {
                    //code 1 as take item
                    case 1:
                        //find backpack, and add item to back pack
                        GameObject.FindGameObjectWithTag("Player")
                            .GetComponentInChildren<Backpack>()
                            .addToBackpack(item);
                        break;
                    //code 2 as take important item
                    case 2:
                        break;
                    //code 3 as take info
                    default:
                        //put info into database, save if no duplicate
                        GameObject.FindGameObjectWithTag("Player")
                            .GetComponentInChildren<Backpack>()
                            .addInfo(info);
                        break;
                }
            }
        }
    
        dText.text = dialogLines[currentLine];
    }

    public void ShowBox()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;       
    }
}
