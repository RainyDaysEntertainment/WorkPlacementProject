﻿using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class consumableSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject slot;
    GameObject icon;
    TextMeshProUGUI amount;
    consumable consumable;
    bool hover;
    GameObject tip;
    TextMeshProUGUI tipDesc;
    Image img;

    private void Start()
    {
        slot = GameObject.Find("consumableSlot");
        icon = GameObject.Find("consumableIcon").GetComponent<Image>().gameObject;
        amount = GameObject.Find("amountText").GetComponent<TextMeshProUGUI>();
        hover = false;
        tip = GameObject.Find("tip");
        tipDesc = GameObject.Find("tipDescription").GetComponent<TextMeshProUGUI>();
        img = GameObject.Find("tipImg").GetComponent<Image>();
        tip.SetActive(false);
    }

    private void Update()
    {
        if(hover == true)
        {
            tip.SetActive(true);
            img.gameObject.SetActive(true);
            tipDesc.text = "Health, one apple restores 1 heart :D";
            if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("Use");
            }
        }
        if (hover == false)
        {
            tip.SetActive(false);
            tipDesc.text = "";
            img.gameObject.SetActive(false);
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
