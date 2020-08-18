using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVariables : MonoBehaviour
{
    public float health = 3;
    public int level = 1;
    public PlayerHealth playerHealth;

    public Animator transition;
    private float transitionTime = 1f;

    public void SavePlayer()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        health = playerHealth.value;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        StartCoroutine(LoadEnum());
    }

    IEnumerator LoadEnum()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;
        playerHealth.value = health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        SceneManager.LoadScene("Player Scene", LoadSceneMode.Single);
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
        transform.position = position;
    }
}
