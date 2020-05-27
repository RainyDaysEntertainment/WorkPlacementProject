using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool trigger = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            trigger = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && trigger)
        {
            TriggerDialogue();
            trigger = false;
        }
        else
        {
            trigger = false;
        }
    }
}
