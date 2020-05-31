using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Quest Item", menuName ="Inventory/Items/QuestItem")]
public class QuestItem : Item
{

    public void Awake()
    {
        type = Type.Quest;
    }
}
