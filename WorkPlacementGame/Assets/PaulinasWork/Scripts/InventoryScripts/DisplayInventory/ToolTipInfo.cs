using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip;
    public TextMeshProUGUI tiptext;
    public Slot Slot;
    private string name1;
    private string description;

    public void Start()
    {
        // tooltip = GameObject.Find("toolTip").GetComponent<Image>().gameObject;
        // tiptext = GameObject.Find("tipText").GetComponentInChildren<TextMeshProUGUI>();        
        tooltip.SetActive(false);
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
        name1 = Slot.item.itemName;
        description = Slot.item.itemDescription;
        tiptext.text = name1 + "" + description;
    }

    public void HideToolTip()
    {
        tiptext.text = "";
        tooltip.SetActive(false);
    }


}
