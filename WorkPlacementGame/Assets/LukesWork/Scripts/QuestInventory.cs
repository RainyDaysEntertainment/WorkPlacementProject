using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInventory : MonoBehaviour
{
    public Image icon;
    Quest item;

    void Start()
    {
        icon = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    public void AddItem(Quest newItem)
    {
        item = newItem;

        icon.sprite = item.QuestImage;
        icon.enabled = true;
    }

    public void ClearItem()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
