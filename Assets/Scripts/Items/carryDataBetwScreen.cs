using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryDataBetwScreen : MonoBehaviour {

    public static carryDataBetwScreen Instance;

    public List<int> items;
    public List<int> infoDB;
    public List<int> eventsDone;
    public List<string> roomExplored;
    public Vector3 posM;


    void Awake()
    {
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
