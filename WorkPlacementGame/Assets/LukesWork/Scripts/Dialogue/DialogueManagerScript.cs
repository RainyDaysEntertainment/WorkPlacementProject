using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox, nameBackground, arrow;
    public LeanTweenType easeType, rotateType, arrowType;

    string statement;

    private Queue<string> statements;

    public bool statementEndBool = true;

    void Start()
    {
        statements = new Queue<string>();
        statementEndBool = true;
        LeanTween.rotateZ(nameBackground, 14, 1.25f).setEase(rotateType).setLoopPingPong();
        LeanTween.moveX(arrow, arrow.transform.position.x + 8, 0.65f).setEase(arrowType).setLoopPingPong();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("DialogueTrigger").GetComponent<DialogueTrigger>().enabled = false;

            if (dialogueText.text != statement)
            {
                StatementSkip();
            }
            else
            {
                NextStatement();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        LeanTween.moveY(dialogueBox, Screen.height / 6, 0.8f).setEase(easeType);
        
        nameText.text = dialogue.characterName;
        nameText.color = dialogue.nameColour;

        statements.Clear();

        statementEndBool = false;

        foreach (string statement in dialogue.statements)
        {
            statements.Enqueue(statement);
        }

        NextStatement();
    }

    public void NextStatement()
    {
        if (statements.Count == 0)
        {
            EndDialogue();
            return;
        }

        statementEndBool = false;

        statement = statements.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LetterByLetterStatement(statement));
    }

    IEnumerator LetterByLetterStatement(string statement)
    {
        dialogueText.text = "";
        statementEndBool = false;
        yield return new WaitForSeconds(0.4f);

        foreach (char letter in statement.ToCharArray())
        {
            dialogueText.text += letter;

            //if (dialogueText.text.Length == statement.Length)
            //{
            //    StopAllCoroutines();
            //}

            yield return new WaitForSeconds(0.02f);
        }
    }

    public void StatementSkip()
    {
        //dialogueText.text = "";
        StopAllCoroutines();
        dialogueText.text = statement;
    }

    public void EndDialogue()
    {
        LeanTween.moveY(dialogueBox, -Screen.height / 2, 0.8f).setEase(easeType);
        GameObject.Find("DialogueTrigger").GetComponent<DialogueTrigger>().enabled = true;
        InvokeRepeating("BoolSwitch", 0.5f, 2000);
    }

    void BoolSwitch()
    {
        statementEndBool = true;
        CancelInvoke("BoolSwitch");
    }
}
