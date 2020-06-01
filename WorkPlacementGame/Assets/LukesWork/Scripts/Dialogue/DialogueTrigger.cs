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
            InvokeRepeating("CancelBool", 0.5f, 10);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (input && other.CompareTag("Player"))
        {
            input = false;
            TriggerDialogue();
        }
    }

    void CancelBool()
    {
        input = false;
        CancelInvoke();
    }
}
