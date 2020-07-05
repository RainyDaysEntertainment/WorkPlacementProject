using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    GameObject inventoryPanel;
    public GameObject itemSlot;
    public GameObject eqSlot1;
    public GameObject eqSlot2;
    void Start()
    {
        inventoryPanel = GameObject.Find("Inv");
        inventoryPanel.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }  

            if(Input.GetKeyDown(KeyCode.Keypad1))
            {
                itemSlot.transform.position = new Vector3(244, 42, 0);
                eqSlot1.transform.position = new Vector3(-208,-417,0);
                eqSlot2.transform.position = new Vector3(-12,-417,0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                eqSlot1.transform.position = new Vector3(244, 42, 0);
                itemSlot.transform.position = new Vector3(184, -417,0);
                eqSlot2.transform.position = new Vector3(-12,-417,0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                eqSlot2.transform.position = new Vector3(244, 42, 0);
                itemSlot.transform.position = new Vector3(184, -417,0);
                eqSlot1.transform.position = new Vector3(-208,-417,0);
            }
        
    }
}
