using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class equipSlot2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject slot;
    public GameObject icon;
    bool hover;
    void Start()
    {
        
    }

    void Update()
    {
        if (hover == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {

            }
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
