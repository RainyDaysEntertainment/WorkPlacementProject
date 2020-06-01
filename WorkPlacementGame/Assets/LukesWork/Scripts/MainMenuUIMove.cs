using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIMove : MonoBehaviour
{
    public float delay;
    public LeanTweenType easeType;
    public GameObject menu;
    public Vector3 pos;
    public bool settings;

    void OnEnable()
    {
        pos = gameObject.transform.position;
        Repeat();
    }

    private void Update()
    {
        if (settings)
        {
            settings = false;
        }
    }

    public void Settings()
    {
        settings = true;
        LeanTween.cancelAll();
        LeanTween.moveX(menu, menu.transform.position.x - (menu.transform.position.x * 2), 2).setEase(easeType);
    }

    public void Repeat()
    {
        LeanTween.moveX(gameObject, gameObject.transform.position.x + (Screen.width / 5.5f), 3).setDelay(delay).setEase(easeType);
    }
}
