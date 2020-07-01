using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Inventory : MonoBehaviour
{
    public List<int> itemDB;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    // Start is called before the first frame update
    void Start()
    {

        itemDB = carryDataBetwScreen.Instance.items;
        //Test if this file works, please uncomment the code below. yxw
        /* 
        for(int i=0; i<2; i++)
        {
            itemDB.Add(i);
        }
        */
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
        RefreshInventory_Items();
    }

    public void RefreshInventory_Items()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSizeX = 300f;
        float itemSlotCellSizeY = 300f;
        GameObject DB = GameObject.FindGameObjectWithTag("DB");

        foreach (int Id in itemDB)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSizeX, y * itemSlotCellSizeY);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = DB.GetComponent<ItemDatabase>().findItemById(Id).item.itemImage;

            Text textName = itemSlotRectTransform.Find("TextName").GetComponent<Text>();
            textName.text = DB.GetComponent<ItemDatabase>().findItemById(Id).item.itemName;
            Debug.Log("it's me!");
            Debug.Log(textName.text);

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
    }
}
