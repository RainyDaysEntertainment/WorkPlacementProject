using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class QuestStart : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject canvas;
    public int i = 0;
    Quest q;

    void OnEnable()
    {
        canvas = GameObject.Find("UICanvas");
        i = ((canvas.transform.childCount - 5) * 80) + 95;

        gameObject.transform.position = new Vector3(Screen.width * 0.82f, Screen.height + 100, 0);
        LeanTween.moveX(gameObject, (Screen.width * 1.105f), 0.5f).setEase(LeanTweenType.easeOutSine).setDelay(4);
        LeanTween.moveY(gameObject, Screen.height - i, 1.25f).setEase(LeanTweenType.easeOutSine);
    }

    public void Update()
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = q.QuestBack;

        if (q.isComplete)
        {
            gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = q.QuestImage;
        }
        else
        {
            gameObject.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = q.QuestImageSilhouette;
        }
    }

    public void GetQuest(Quest quest)
    {
        q = quest;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.moveX(gameObject, (Screen.width * 0.82f), 0.5f).setEase(LeanTweenType.easeOutSine);
        LeanTween.moveY(gameObject, Screen.height - i, 0.5f).setEase(LeanTweenType.easeOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.moveX(gameObject, (Screen.width * 1.105f), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeOutSine);
    }
}
