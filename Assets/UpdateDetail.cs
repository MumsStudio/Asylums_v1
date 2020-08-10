using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDetail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateInfoDetail(string title, string detail)
    {
        Text InfoTitle = transform.Find("InfoTitle").GetComponent<Text>();
        Text InfoDetails = transform.Find("InfoDetails").GetComponent<Text>();
        InfoTitle.text = title;
        InfoDetails.text = detail;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
