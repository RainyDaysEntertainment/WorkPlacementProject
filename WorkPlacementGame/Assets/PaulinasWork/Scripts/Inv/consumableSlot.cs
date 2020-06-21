using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class consumableSlot : MonoBehaviour
{
    GameObject slot;
    GameObject icon;
    TextMeshProUGUI amount;

    private void Start()
    {
        slot = GameObject.Find("consumableSlot");
        icon = GameObject.Find("consumableIcon").GetComponent<Image>().gameObject;
        amount = GameObject.Find("amountText").GetComponent<TextMeshProUGUI>();
    }

}
