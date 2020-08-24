using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue, finishedDialogue;
    public DialogueManagerScript manager;
    public bool input, activeQuest = false;

    public QuestGiver NPC;
    Quest quest;
    public QuestInv questInv;

    private void Start()
    {
        activeQuest = false;

        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManagerScript>();
        NPC = gameObject.GetComponentInParent<QuestGiver>();
        quest = NPC.quest;

        questInv = GameObject.Find("GameManager").GetComponent<QuestInv>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && manager.statementEndBool)
        {
            input = true;
            InvokeRepeating("CancelBool", 0.1f, 10);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().StartDialogue(dialogue);
    }

    public void TriggerCompletedDialogue()
    {
        finishedDialogue.nameColour = dialogue.nameColour;
        finishedDialogue.characterName = dialogue.characterName;

        FindObjectOfType<DialogueManagerScript>().StartDialogue(finishedDialogue);

        if (quest.isComplete)
            questInv.Remove(quest);
    }

    private void OnTriggerStay(Collider other)
    {
        if (input && other.CompareTag("Player") && quest.isComplete)
        {
            input = false;
            TriggerCompletedDialogue();
        }
        else if (input && other.CompareTag("Player"))
        {
            input = false;
            TriggerDialogue();
        }

        if (activeQuest == false && Input.GetKeyDown(KeyCode.E))
        {
            NPC.PopupQuestMessage();
            activeQuest = true;

            //Destroy(NPC.GetComponent<DialogueManagerScript>());
            //gameObject.AddComponent<DialogueManagerScript>();
        }
    }

    void CancelBool()
    {
        input = false;
        CancelInvoke();
    }
}
