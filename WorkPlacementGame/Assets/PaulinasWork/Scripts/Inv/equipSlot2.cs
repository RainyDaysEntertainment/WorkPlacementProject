using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class equipSlot2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject slot;
    GameObject icon;
    bool hover;
    void Start()
    {
        slot = GameObject.Find("equip2");
        icon = GameObject.Find("eq2img");
    }

    void Update()
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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
        hover = false;
    }
}
