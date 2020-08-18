using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class weaponSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hover;
    GameObject tip;
    TextMeshProUGUI tipDesc;

    private void Start()
    {
        tip = GameObject.Find("tip");
        tipDesc = GameObject.Find("tipDescription").GetComponent<TextMeshProUGUI>();
        hover = false;
        
    }

    private void Update()
    {
        if (hover == true)
        {
         
        }
        if (hover == false)
        {
     
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        hover = true;
        tip.SetActive(true);
        tipDesc.text = "One of a kind sword! Does decent damage.";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        hover = false;
        tipDesc.text = "";
    }
}
