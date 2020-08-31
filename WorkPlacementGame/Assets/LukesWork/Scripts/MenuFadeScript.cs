using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFadeScript : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1f;
    public int levelNum = 2;
    public GameObject player;
    PlayerVariables variables;
    public Button loadBtn;

    private void Start()
    {
        player = GameObject.Find("Player");

        variables = player.GetComponent<PlayerVariables>();

        loadBtn.interactable = false;

        string path = Application.persistentDataPath + "/PlayerData.poop";

        if (File.Exists(path))
        {
            loadBtn.interactable = true;
        }
    }

    private void Update()
    {
        player.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void NewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.poop"))
        {
            File.Delete(Application.persistentDataPath + "/PlayerData.poop");
        }

        StartCoroutine(LoadSceneIEnum(2));
    }
    IEnumerator LoadSceneIEnum(int levelNumber)
    {
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

        player.GetComponent<Rigidbody>().isKinematic = false;
        player.transform.position = new Vector3(50, 1.1f, 6);

        SceneManager.LoadScene(levelNumber, LoadSceneMode.Additive);

        transition.ResetTrigger("Start");
    }

    public void LoadGame()
    {
        variables.LoadPlayer();
    }
}
