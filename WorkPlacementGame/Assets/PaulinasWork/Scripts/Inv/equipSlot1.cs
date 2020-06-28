using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class equipSlot1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject slot;
    GameObject icon;
    bool hover;

    void Start()
    {
        slot = GameObject.Find("equip1");    
        icon = GameObject.Find("eq1Img");
    }

    void Update()
    {
        if(hover == true)
        {
           
        }
        if(hover == false)
        {
            
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        hover = false;
    }
}
