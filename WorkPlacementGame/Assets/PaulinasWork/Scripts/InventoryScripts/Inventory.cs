using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName ="Inventory", menuName ="Inventory/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Slot> InventoryItems = new List<Slot>();

    public void AddItem(Item item)
    {
        bool slotTaken = false;
        for (int i = 0; i < InventoryItems.Count; i++)
        {
            if (InventoryItems[i].item == item)
            {
                slotTaken = true;
                break;
            }
        }
        if (!slotTaken)
        {
            InventoryItems.Add(new Slot(item));
        }
    }

  
}
