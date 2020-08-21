using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInv : MonoBehaviour
{
    public static QuestInv instance;
    int space = 8;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple inventories!");
            return;
        }

        instance = this;
    }

    public List<Quest> items = new List<Quest>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Quest item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Full inventory!");
            return false;
        }

        item.isComplete = true;
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Quest item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
