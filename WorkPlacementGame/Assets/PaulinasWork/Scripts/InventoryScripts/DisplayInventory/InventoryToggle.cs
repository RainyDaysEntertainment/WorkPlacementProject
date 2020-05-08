using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public Canvas canvas;
    public bool isOpen = false;
    void Start()
    {
        canvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            canvas.enabled = !canvas.enabled;
        }

        if (canvas.enabled == true)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
    }
}
