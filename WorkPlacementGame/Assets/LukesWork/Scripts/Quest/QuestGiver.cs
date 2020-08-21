using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public GameObject questPopup, canvas, dialogueTrigger;

    public int i;

    public Sprite incompleteImage, completeImage;

    //public TextMeshPro title, description;

    private void Start()
    {
        //dialogueTrigger = GameObject.Find
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PopupQuestMessage();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            quest.isComplete = true;
        }

        if (quest.isComplete == false)
        {
            quest.QuestBack = incompleteImage;
        }
        else
        {
            quest.QuestBack = completeImage;
        }
    }

    public void PopupQuestMessage()
    {
        GameObject questObj = Instantiate(questPopup, canvas.transform);

        questObj.GetComponent<QuestStart>().GetQuest(quest);

        //title = questObj.transform.GetChild(3).GetComponent<TextMeshPro>();//QuestName QuestDesc
        //description = questObj.transform.GetChild(4).GetComponent<TextMeshPro>();

        questObj.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = quest.QuestTitle;
        questObj.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = quest.QuestDescription;

        //GameObject dialogue = gameObject.transform.GetChild(0).gameObject;

        //Destroy(dialogue.GetComponent<DialogueManagerScript>());
        //dialogue.AddComponent<DialogueManagerScript>();
    }
}
