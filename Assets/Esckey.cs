using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esckey : MonoBehaviour {
    public GameObject EscMenue;
    public GameObject SceneObject;
    public GameObject PlayerObject;

    public GameObject Menue;
    public GameObject PlayerInfor;
    public GameObject Backpack;
    public GameObject Option;
    public GameObject GameData;

    public void Esc()
    {
        //ESC keyword active menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscMenue.SetActive(true);
            SceneObject.SetActive(false);
            PlayerObject.SetActive(false);
        }
        if (EscMenue.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("11111");
            if (PlayerInfor.activeSelf)
            {
                PlayerInfor.SetActive(false);
                Menue.SetActive(true);
            }
            else
            {
                EscMenue.SetActive(false);
                SceneObject.SetActive(true);
                PlayerObject.SetActive(true);
            }
            
        }
    }	
}
