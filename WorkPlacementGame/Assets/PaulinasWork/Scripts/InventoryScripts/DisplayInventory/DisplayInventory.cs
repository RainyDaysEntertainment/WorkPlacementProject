using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotholder;

    void Start()
    {
        allSlots = 21;
        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotholder.transform.GetChild(i).gameObject;
        }
    }
}
