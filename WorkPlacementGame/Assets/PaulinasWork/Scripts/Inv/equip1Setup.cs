using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class equip1Setup : MonoBehaviour
{
    int amount;
    GameObject equipSlot1;
    TextMeshProUGUI amtTxt;
    GameObject Icon;
    bool hover;

    void Start()
    {
        equipSlot1 = GameObject.Find("equip1");
        amtTxt = GameObject.Find("eq1Txt").GetComponentInChildren<TextMeshProUGUI>();
        Icon = GameObject.Find("eq1Img");
        amount = 0;
        Icon.SetActive(false);
    }

    void Update()
    {
        if(amount>=1)
        {
            Icon.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        amtTxt.text = amount.ToString();
        if (other.tag == "Bomb")
        {
            amount++;
            Destroy(other.gameObject);
           
        }
    }
}
