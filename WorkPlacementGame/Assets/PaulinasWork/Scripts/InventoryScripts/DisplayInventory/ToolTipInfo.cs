using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject tooltip;
    TextMeshProUGUI tiptext;
    private string name1;
    private string description;
    Inventory inventory;
    Slot slot;


    public void Start()
    { 
        tooltip = GameObject.Find("toolTip").GetComponent<Image>().gameObject;
        tiptext = GameObject.Find("tipText").GetComponentInChildren<TextMeshProUGUI>();        
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
    }
    public void ShowInfo()
    {
        tiptext.text = name1 + "" + description;
    }

    public void HideToolTip()
    {
        tooltip.SetActive(false);
    }


}
