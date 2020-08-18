using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class consumableSetup : MonoBehaviour
{
    int amount;
    public  GameObject consumableSlot;
    public TextMeshProUGUI amtTxt;
    public GameObject Icon;
    bool hover;

    private void Start()
    {
        //consumableSlot = GameObject.Find("itemSlot");
       // amtTxt = GameObject.Find("amountText").GetComponent<TextMeshProUGUI>();
        //Icon = GameObject.Find("consumableIcon").GetComponent<Sprite>();
        //amtTxt.text = amount.ToString();
        amtTxt.text = amount.ToString();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Consumable")
        {
            amount++;
            amtTxt.text = amount.ToString();
            Destroy(other.gameObject);          
        }
      
    }
}
