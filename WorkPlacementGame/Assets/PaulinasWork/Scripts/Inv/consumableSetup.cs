using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class consumableSetup : MonoBehaviour
{
    consumable consumable;
    int amount;
    GameObject consumableSlot;
    TextMeshProUGUI amtTxt;
    Sprite Icon;

    private void Start()
    {
        consumableSlot = GameObject.Find("consumableSlot");
        amtTxt = GameObject.Find("amountText").GetComponentInChildren<TextMeshProUGUI>();
        Icon = GameObject.Find("consumableIcon").GetComponentInChildren<Sprite>();
        //amtTxt.text = amount.ToString();
        amount = 0;
        Icon = consumable.icon;
    }

    private void Update()
    {
        amtTxt.text = amount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {      
        if(other.tag == "Consumable")
        {
            amount++;
            Destroy(other.gameObject);
        }
    }
}
