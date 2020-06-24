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
    Image img;

    private void Start()
    {
        tip = GameObject.Find("tip");
        tipDesc = GameObject.Find("tipDescription").GetComponent<TextMeshProUGUI>();
        img = GameObject.Find("tipImg").GetComponent<Image>();
        hover = false;
        tip.SetActive(false);
    }

    private void Update()
    {
        if (hover == true)
        {
            tip.SetActive(true);
            img.gameObject.SetActive(true);
            tipDesc.text = "One of a kind sword! Does decent damage.";
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
