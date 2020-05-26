using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class PhysicalSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    //Panel DisplayPanel;
    GameObject tooltip;
    TextMeshProUGUI tiptext;
    private TextMeshProUGUI name1;
    private string amt;
    private string description;
    public Inventory inventory;

    public void Awake()
    {
        //DisplayPanel = GameObject.Find("InventoryPanel").GetComponent<Panel>();
        //tooltip.GetComponentInChildren<TextMeshProUGUI>().text = tiptext.text;
        tooltip = GameObject.Find("toolTip").GetComponent<Image>().gameObject;
        tiptext = GameObject.Find("tipText").GetComponent<TextMeshProUGUI>();
        name1 = this.GetComponentInChildren<TextMeshProUGUI>();
        tooltip.SetActive(false);
    }

    public void Update()
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    #region TooltipMethods
    public void OnPointerEnter(PointerEventData eventData)
    {
        //ShowToolTip();
        ShowInfo();
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
    }

    public void ShowInfo()
    {
        foreach (Slot s in inventory.InventoryItems)
        {
            if (s.item.itemName == name1.text)
            {
                tiptext.text = s.item.itemName + " - " + s.item.itemDescription;
                ShowToolTip();
            }
        }
    }
    #endregion
}
