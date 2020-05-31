using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon Item",menuName ="Inventory/Items/WeaponItem")]
public class WeaponItem : Item
{
    public int damage;
    public void Awake()
    {
        type = Type.Weapon;
    }
}
