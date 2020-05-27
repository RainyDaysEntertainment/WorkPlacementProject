using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject dialogueBox;
    public LeanTweenType easeType;

    string statement;

    private Queue<string> statements;

    bool statementEndBool = false;

    void Start()
    {
        statements = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StatementSkip();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        LeanTween.moveY(dialogueBox, 100, 0.5f).setEase(easeType);

        nameText.text = dialogue.characterName;

        statements.Clear();

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

        statement = statements.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LetterByLetterStatement(statement));
    }

    IEnumerator LetterByLetterStatement(string statement)
    {
        dialogueText.text = "";
        statementEndBool = false;
        yield return new WaitForSeconds(0.5f);

        foreach (char letter in statement.ToCharArray())
        {
            dialogueText.text += letter;

            if (dialogueText.text.Length == statement.Length)
            {
                statementEndBool = true;
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    public void StatementSkip()
    {
        //dialogueText.text = "";
        dialogueText.text = statement;
        StopAllCoroutines();
    }

    public void EndDialogue()
    {
        LeanTween.moveY(dialogueBox, -100, 0.5f).setEase(easeType);
    }
}
