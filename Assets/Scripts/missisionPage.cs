using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missisionPage : MonoBehaviour
{
    public Button mission1;
    public Button mission2;
    public Button mission3;
    public Text content;


    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = mission1.GetComponent<Button>();
        btn1.onClick.AddListener(delegate (){ content.text = "Search 7 floor and find the way out"; });

        
    }

    
}
