using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { Quest, Consumable, Weapon }

[CreateAssetMenu(fileName ="Item",menuName ="Inventory/Item")]
public abstract class Item : ScriptableObject
{
    public string itemName;
    [TextArea(20,30)]
    public string itemDescription;
    public GameObject gameObject;
    public Type type;
}
