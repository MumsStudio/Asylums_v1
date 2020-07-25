using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Inventory : MonoBehaviour
{
    public List<int> items;
    private GameObject DB;


    // Start is called before the first frame update
    void Start()
    {

        items = carryDataBetwScreen.Instance.items;
        GameObject DB = GameObject.FindGameObjectWithTag("DB");
        //Test if this file works, please uncomment the code below. yxw
        /* 
        for(int i=0; i<2; i++)
        {
            itemDB.Add(i);
        }
        */

        RefreshInventory_Item();
    }

    public void RefreshInventory_Item()
    {
        Transform itemSlotContainer = transform.Find("ItemSlotContainer");
        Transform itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSizeX = 300f;
        float itemSlotCellSizeY = 300f;

        foreach (int Id in items)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSizeX, y * itemSlotCellSizeY);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = DB.GetComponent<ItemDatabase>().findItemById(Id).item.itemImage;

            Text textName = itemSlotRectTransform.Find("TextName").GetComponent<Text>();
            textName.text = DB.GetComponent<ItemDatabase>().findItemById(Id).item.itemName;

            Text textDesc = itemSlotRectTransform.Find("TextDesc").GetComponent<Text>();
            textDesc.text = DB.GetComponent<ItemDatabase>().findItemById(Id).item.description;

            x++;
            if(x >= 2)
            {
                x = 0;
                y--;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Backpack.itemDB_isChanged is true)
        {
            RefreshInventory_Item();
            Backpack.itemDB_isChanged = false;
        }
    }
}
