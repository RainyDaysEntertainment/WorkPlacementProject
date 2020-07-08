using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class equip1Setup : MonoBehaviour
{
    int amount;
    public GameObject equipSlot1;
    public GameObject Icon;
    bool hover;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            amount++;
            Destroy(other.gameObject);
           
        }
    }
}
