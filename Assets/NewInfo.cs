using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInfo : MonoBehaviour
{
    public List<int> items;
    public List<int> infoDB;
    public List<DatabaseInfordb> infoDBDetail;
    public List<DatabaseInfordb> backpackInfo;

    // Start is called before the first frame update
    void Start()
    {
        items = carryDataBetwScreen.Instance.items;
        infoDB = carryDataBetwScreen.Instance.infoDB;
        GetInfoLength(infoDB, infoDBDetail);
    }

    public List<DatabaseInfordb> GetInfoLength(List<int> infoDB, List<DatabaseInfordb> infoDBDetail)
    {
        if (infoDB.Count != 0) {
            foreach (int i in infoDB)
            {
                Debug.Log("it's me!" + infoDBDetail[i]);
                backpackInfo.Add(infoDBDetail[i]);
            }
        } 
        return backpackInfo;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
