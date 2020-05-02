using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Slot 
{
    public Item item;

    public Slot(Item _item )
    {
        item = _item;
    }
}
