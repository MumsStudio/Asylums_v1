using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_Inventory : MonoBehaviour
{
    public List<int> infoDB;
    private Transform infoSlotContainer;
    private Transform infoSlotTemplate;

    // Start is called before the first frame update
    void Start()
    {
        infoDB = carryDataBetwScreen.Instance.infoDB;
        //Test if this file works, please uncomment the code below. yxw
        /*
        for (int i=0; i<2; i++)
        {
            infoDB.Add(i);
        }*/
        
        infoSlotContainer = transform.Find("InfoSlotContainer");
        infoSlotTemplate = infoSlotContainer.Find("InfoSlotTemplate");
        RefreshInventoryItems();
    }

    public void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float infoSlotCellSizeX = 400f;
        float infoSlotCellSizeY = 400f;
        GameObject DB = GameObject.FindGameObjectWithTag("DB");

        foreach (int Id in infoDB)
        {
            RectTransform infoSlotRectTransform = Instantiate(infoSlotTemplate, infoSlotContainer).GetComponent<RectTransform>();
            infoSlotRectTransform.gameObject.SetActive(true);

            infoSlotRectTransform.anchoredPosition = new Vector2(x * infoSlotCellSizeX, y * infoSlotCellSizeY);

            Text textTitle = infoSlotRectTransform.Find("TextTitle").GetComponent<Text>();
            textTitle.text = DB.GetComponent<ItemDatabase>().findInfoById(Id).Infordb.infoTitle;

            Text textDesc = infoSlotRectTransform.Find("TextDesc").GetComponent<Text>();
            textDesc.text = DB.GetComponent<ItemDatabase>().findInfoById(Id).Infordb.description;

            x++;
            if (x >= 3)
            {
                x = 0;
                y--;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}