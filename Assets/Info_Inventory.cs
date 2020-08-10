using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_Inventory : MonoBehaviour
{
    public List<int> infoDB;
    private GameObject DB;

    // Start is called before the first frame update
    void Start()
    {
        infoDB = carryDataBetwScreen.Instance.infoDB;
        DB = GameObject.FindGameObjectWithTag("DB");

        //Test if this file works, please uncomment the code below. yxw
        /*
        for (int i=0; i<2; i++)
        {
            infoDB.Add(i);
        }*/

        RefreshInventory_Info();
    }

    public void RefreshInventory_Info()
    {
        Transform infoSlotContainer = transform.Find("Viewport/Content");
        Transform infoSlotTemplate = infoSlotContainer.Find("Button");
        foreach(Transform child in infoSlotContainer)
        {
            if (child == infoSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        //float x0 = infoSlotTemplate.position.x;
        //float y0 = infoSlotTemplate.position.y;
        float x0 = 0;
        float y0 = 134.5f;
        int count = 0;
        float infoSlotCellSizeY = -40f;


        foreach (int Id in infoDB)
        {
            RectTransform infoSlotRectTransform = Instantiate(infoSlotTemplate, infoSlotContainer).GetComponent<RectTransform>();
            infoSlotRectTransform.gameObject.SetActive(true);

            infoSlotRectTransform.anchoredPosition = new Vector2(x0,  y0 + count*infoSlotCellSizeY);
            

            Text textTitle = infoSlotRectTransform.Find("Text").GetComponent<Text>();
            textTitle.text = DB.GetComponent<ItemDatabase>().findInfoById(Id).Infordb.infoTitle;
            // not sure how to simplify the following sentenses:
            infoSlotRectTransform.gameObject.GetComponent<infoHolderforDetails>().title = textTitle.text;
            infoSlotRectTransform.gameObject.GetComponent<infoHolderforDetails>().detail=DB.GetComponent<ItemDatabase>().findInfoById(Id).Infordb.description;
            count++;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}