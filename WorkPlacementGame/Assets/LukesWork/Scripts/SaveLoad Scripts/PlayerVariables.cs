using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerVariables : MonoBehaviour
{
    public float health = 3;
    public int level = 0;
    public PlayerHealth playerHealth;

    public Animator transition;
    private float transitionTime = 1f;

    SceneSwitcher switcher;

    public PauseMenu pause;
    public Button loadBtn;

    private void Start()
    {
        switcher = GetComponent<SceneSwitcher>();
        pause = GameObject.Find("UICanvas").GetComponent<PauseMenu>();

        loadBtn.interactable = false;
    }

    private void Update()
    {
        string path = Application.persistentDataPath + "/PlayerData.poop";

        if (File.Exists(path))
        {
            loadBtn.interactable = true;
        }
        else
        {
            loadBtn.interactable = false;
        }
    }

    public void SavePlayer()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name != "Player Scene")
            {
                level = scene.buildIndex;
            }
        }

        health = playerHealth.hValue;
        health = playerHealth.Value;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        StartCoroutine(LoadEnum());
    }

    IEnumerator LoadEnum()
    {
        pause.menuActive = false;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name != "Player Scene")
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }

        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        playerHealth.Value = health;

        switcher.cam.SetActive(false);
        if (level == 2)
        {
            switcher.cam.SetActive(true);
        }

        SceneManager.LoadScene(level, LoadSceneMode.Additive);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        GetComponent<Rigidbody>().isKinematic = false;

        transition.ResetTrigger("Start");
        transition.ResetTrigger("End");
    }
}
