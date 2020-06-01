using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNotifBounce : MonoBehaviour
{
    public LeanTweenType easeType;

    void Start()
    {
        LeanTween.moveY(gameObject, gameObject.transform.position.y + 0.5f, 1.5f).setLoopPingPong().setEase(easeType);
    }
}
