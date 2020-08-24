using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUIMover : MonoBehaviour
{
    bool isShowing = false;

    private void Start()
    {
        LeanTween.moveX(gameObject, (Screen.width * 1.175f), 0);
    }

    public void Mover()
    {
        isShowing = !isShowing;

        if (isShowing)
        {
            LeanTween.moveX(gameObject, (Screen.width * 0.84f), 0.6f).setEase(LeanTweenType.easeOutBounce);
        }
        else
        {
            LeanTween.moveX(gameObject, (Screen.width * 1.175f), 0.6f).setEase(LeanTweenType.easeOutBounce);
        }
    }
}
