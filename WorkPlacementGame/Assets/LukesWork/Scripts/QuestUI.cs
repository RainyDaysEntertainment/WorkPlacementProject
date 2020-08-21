using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public Transform slotsParent;
    QuestInventory[] slots;

    QuestInv qInventory;

    void Start()
    {
        qInventory = QuestInv.instance;
        qInventory.onItemChangedCallback += UpdateUI;

        slotsParent = GameObject.Find("QuestItemPanel").transform;
        slots = slotsParent.GetComponentsInChildren<QuestInventory>();
    }

    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < qInventory.items.Count)
            {
                slots[i].AddItem(qInventory.items[i]);
            }
            else
            {
                slots[i].ClearItem();
            }
        }
    }
}
