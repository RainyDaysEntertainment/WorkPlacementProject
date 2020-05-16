using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotDisplay : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory inventory;
    Dictionary<Slot, GameObject> itemsDisplay = new Dictionary<Slot, GameObject>();
    public int x_space;
    public int y_space;
    public int colmn;
    private GameObject tooltip;
    private TextMeshProUGUI tiptext;

    public void Start()
    {
        tooltip = GameObject.Find("toolTip").GetComponent<Image>().gameObject;
        tiptext = GameObject.Find("tipText").GetComponent<TextMeshProUGUI>();
        tooltip.SetActive(false);
        Create();
    }

    private void Update()
    {
        UpdateDisplay();
        DisplayInfo();
    }

    private void UpdateDisplay()
    {
       for(int i=0;i<inventory.InventoryItems.Count;i++)
        {
            if(itemsDisplay.ContainsKey(inventory.InventoryItems[i]))
            {
                itemsDisplay[inventory.InventoryItems[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.InventoryItems[i].item.itemName;
                itemsDisplay[inventory.InventoryItems[i]].GetComponentInChildren<Text>().text = inventory.InventoryItems[i].amount.ToString();
            }
            else
            {
                var obj = Instantiate(inventory.InventoryItems[i].item.gameObject, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.InventoryItems[i].item.itemName;
                obj.GetComponentInChildren<Text>().text = inventory.InventoryItems[i].amount.ToString();
                itemsDisplay.Add(inventory.InventoryItems[i], obj);
            }
        }
    }

    public void Create()
    {
        for(int i = 0; i < inventory.InventoryItems.Count; i++)
        {
            var obj = Instantiate(inventory.InventoryItems[i].item.gameObject, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.InventoryItems[i].item.itemName;
            obj.GetComponentInChildren<Text>().text = inventory.InventoryItems[i].amount.ToString();
            itemsDisplay.Add(inventory.InventoryItems[i], obj);
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(x_space *(i % colmn), (-y_space * (i/colmn)), 0f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowToolTip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideToolTip();
    }

    public void ShowToolTip()
    {
        tooltip.SetActive(true);
    }

    public void HideToolTip()
    {
        tooltip.SetActive(false);
        tiptext.text = "";
    }

    public void DisplayInfo()
    {
        for (int i = 0; i < inventory.InventoryItems.Count; i++)
        {
            if (itemsDisplay.ContainsKey(inventory.InventoryItems[i]))
            {
                tiptext.text
                   = inventory.InventoryItems[i].item.itemName.ToString() + " " + inventory.InventoryItems[i].item.itemDescription.ToString();
            }
        }
    }
}
