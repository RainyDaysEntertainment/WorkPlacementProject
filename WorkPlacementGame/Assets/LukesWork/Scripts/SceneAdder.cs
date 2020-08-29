using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAdder : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }
}
