using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFadeScript : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;
    public int levelNum = 2;

    public void Fade()
    {
        StartCoroutine(LoadSceneIEnum(levelNum));
    }

    IEnumerator LoadSceneIEnum(int levelNumber)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelNumber);
    }
}
