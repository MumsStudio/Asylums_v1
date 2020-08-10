using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoHolderforDetails : MonoBehaviour
{
    public string detail;
    public string title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetInfoDetails()
    {
        Transform InfoList = transform.parent.parent.parent;
        InfoList.GetComponentInChildren<UpdateDetail>().UpdateInfoDetail(title, detail);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
