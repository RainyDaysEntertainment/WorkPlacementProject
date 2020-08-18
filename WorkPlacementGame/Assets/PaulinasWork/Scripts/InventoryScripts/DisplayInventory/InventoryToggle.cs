using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    GameObject inventoryPanel;
    public GameObject itemSlot;
    public GameObject eqSlot1;
    public GameObject eqSlot2;
    public GameObject HUDimg;
    GameObject img;
    void Start()
    {
        inventoryPanel = GameObject.Find("Inv");
        inventoryPanel.SetActive(false);
        img = GameObject.Find("slot2").GetComponentInChildren<GameObject>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryPanel.activeSelf;
            inventoryPanel.SetActive(!isActive);
        }

        if(inventoryPanel.activeSelf)
        {
            Debug.Log("!");
            if (Input.GetKeyDown(KeyCode.Y))
            {
                itemSlot.transform.localPosition = new Vector3(244, 42, 0);
                eqSlot1.transform.localPosition = new Vector3(-208, -417, 0);
                eqSlot2.transform.localPosition = new Vector3(-12, -417, 0);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                eqSlot1.transform.localPosition = new Vector3(244, 42, 0);
                itemSlot.transform.localPosition = new Vector3(184, -417, 0);
                eqSlot2.transform.localPosition = new Vector3(-12, -417, 0);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                eqSlot2.transform.localPosition = new Vector3(244, 42, 0);
                itemSlot.transform.localPosition = new Vector3(184, -417, 0);
                eqSlot1.transform.localPosition = new Vector3(-208, -417, 0);
            }

        }
    }
}
