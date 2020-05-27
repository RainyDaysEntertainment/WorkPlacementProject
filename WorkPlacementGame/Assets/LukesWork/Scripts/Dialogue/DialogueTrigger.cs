using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManagerScript manager;
    public bool input;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && manager.statementEndBool)
        {
            input = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (input)
        {
            input = false;
            TriggerDialogue();
        }
    }
}
