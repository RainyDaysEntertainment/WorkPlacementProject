using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInvTrigger : MonoBehaviour
{
    public Inventory inv;

    private void OnApplicationQuit()
    {
        inv.InventoryItems.Clear();
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemObject>();
        if (item)
        {
            inv.AddItem(item.item);
            Destroy(other.gameObject);
        }
    }

}
