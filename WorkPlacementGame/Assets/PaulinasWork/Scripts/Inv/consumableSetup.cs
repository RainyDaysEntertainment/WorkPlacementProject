using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class consumableSetup : MonoBehaviour
{
    consumable consumable;
    int amount;
    TextMeshProUGUI amtTxt;
    Texture Icon;

    private void Start()
    {
        amtTxt = GameObject.Find("amountText").GetComponent<TextMeshProUGUI>();
        Icon = GameObject.Find("consumableIcon").GetComponent<Texture>();
        amount = 0;
    }

    private void Update()
    {
        Icon = consumable.icon.mainTexture;
        amtTxt.text = amount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<consumable>();
        if(item)
        {
            amount++;
            Destroy(other.gameObject);
        }
    }
}
