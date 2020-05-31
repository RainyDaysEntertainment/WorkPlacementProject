using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Consumable Item", menuName ="Inventory/Items/ConsumableItem")]
public class ConsumableItem : Item
{
    public int health;
    public void Awake()
    {
        type = Type.Consumable;
    }
}
