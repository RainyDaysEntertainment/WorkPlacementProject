using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnim : MonoBehaviour
{
    public float rot = 0;

    void Start()
    {
        //LeanTween.moveX(gameObject, (Screen.width * 0.84f), 0.6f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.rotateY(gameObject, 90, 3f).setEase(LeanTweenType.linear);
        LeanTween.rotateY(gameObject, 180, 3f).setEase(LeanTweenType.linear).setDelay(3);
    }

    private void Update()
    {
        rot = gameObject.transform.rotation.eulerAngles.y + 10;
    }
}
