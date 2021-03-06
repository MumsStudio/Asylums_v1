﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryDataBetwScreen : MonoBehaviour {

    public static carryDataBetwScreen Instance;

    public List<int> items;
    public List<int> infoDB;
    public List<int> eventsDone;
    public List<string> roomExplored;
    public Vector3 posM;
    public Vector3 camPos;

    public static string prevScene = "";

    void Awake()
    {
        if (prevScene == "_8FB")
        {
            GameObject ChangeLevel = GameObject.FindGameObjectsWithTag("ChangeLevel")[0];
            LevelControl LevelControl = ChangeLevel.GetComponent<LevelControl>();
            LevelControl.player.transform.position = new Vector3(9, 0, 0);
            LevelControl.cam.transform.position = new Vector3(9, 0, -1);
        }

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
