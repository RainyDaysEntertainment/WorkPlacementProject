using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdder : MonoBehaviour
{
    public string lScene = "MainScene";

    void OnEnable()
    {
        SceneManager.LoadScene(lScene, LoadSceneMode.Additive);
    }
}