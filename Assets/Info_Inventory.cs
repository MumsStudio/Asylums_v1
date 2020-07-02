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
        Transform infoSlotContainer = transform.Find("InfoSlotContainer");
        Transform infoSlotTemplate = infoSlotContainer.Find("InfoSlotTemplate");
        foreach(Transform child in infoSlotContainer)
        {
            if (child == infoSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float infoSlotCellSizeX = 400f;
        float infoSlotCellSizeY = 400f;


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
        if (Backpack.infoDB_isChanged is true)
        {
            RefreshInventory_Info();
            Backpack.infoDB_isChanged = false;
        }
    }
}