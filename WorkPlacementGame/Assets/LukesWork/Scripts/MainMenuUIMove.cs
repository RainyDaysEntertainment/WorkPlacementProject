using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIMove : MonoBehaviour
{
    public float delay;
    public LeanTweenType easeType;

    void OnEnable()
    {
        LeanTween.moveX(gameObject, gameObject.transform.position.x + 350, 3).setDelay(delay).setEase(easeType);
    }
}
