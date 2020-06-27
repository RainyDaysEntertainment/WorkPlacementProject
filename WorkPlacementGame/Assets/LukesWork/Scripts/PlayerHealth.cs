using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float value;
    float decreaseValue = 1f;

    [HideInInspector]
    public bool canIncrease = true, ease0, ease1, ease2, ease3;

    GameObject player, health;
    public GameObject healthIcon1, healthIcon2, healthIcon3;
    public Sprite fullHeart, emptyHeart;

    public ScreenShake screenShake;

    public LeanTweenType easeType, easeType2;

    AudioSource healSound;

    void Start()
    {
        player = GameObject.Find("Player");
        health = GameObject.Find("HealthIcons");

        value = 3;
        screenShake = GameObject.Find("Camera").GetComponent<ScreenShake>();

        healSound = player.GetComponent<AudioSource>();
    }

    void Update()
    {
        //health.GetComponent<Slider>().value = value;

        //if (value < healthSlider.GetComponent<Slider>().maxValue && canIncrease && Time.timeScale != 0)
        //{
        //    value += increaseValue;
        //}

        if (value <= 0)
        {
            value = 0;

            if (ease0)
            {
                healthIcon1.GetComponent<Image>().sprite = emptyHeart;
                healthIcon2.GetComponent<Image>().sprite = emptyHeart;
                healthIcon3.GetComponent<Image>().sprite = emptyHeart;

                LeanTween.scale(healthIcon1, new Vector3(0.1f, 0.1f, 0.1f), 0.2f).setEase(easeType2);
                LeanTween.scale(healthIcon2, new Vector3(0.1f, 0.1f, 0.1f), 0.2f).setEase(easeType2);
                LeanTween.scale(healthIcon3, new Vector3(0.1f, 0.1f, 0.1f), 0.2f).setEase(easeType2);

                ease0 = false;
            }

            GameOverScreen();
        }
        else
        {
            ease0 = true;
        }

        if (value == 1)
        {
            if (ease1)
            {
                healthIcon1.GetComponent<Image>().sprite = fullHeart;
                healthIcon2.GetComponent<Image>().sprite = emptyHeart;
                healthIcon3.GetComponent<Image>().sprite = emptyHeart;

                LeanTween.scale(healthIcon1, new Vector3(0.2f, 0.2f, 0.2f), 0.2f).setEase(easeType);
                LeanTween.scale(healthIcon1, new Vector3(0.15f, 0.15f, 0.15f), 0.2f).setEase(easeType).setDelay(0.2f);

                LeanTween.scale(healthIcon2, new Vector3(0.1f, 0.1f, 0.1f), 0.2f).setEase(easeType2);
                LeanTween.scale(healthIcon3, new Vector3(0.1f, 0.1f, 0.1f), 0.2f).setEase(easeType2);

                ease1 = false;
            }
        }
        else
        {
            ease1 = true;
        }

        if (value == 2)
        {
            if (ease2)
            {
                healthIcon1.GetComponent<Image>().sprite = fullHeart;
                healthIcon2.GetComponent<Image>().sprite = fullHeart;
                healthIcon3.GetComponent<Image>().sprite = emptyHeart;

                LeanTween.scale(healthIcon2, new Vector3(0.2f, 0.2f, 0.2f), 0.2f).setEase(easeType);
                LeanTween.scale(healthIcon2, new Vector3(0.15f, 0.15f, 0.15f), 0.2f).setEase(easeType).setDelay(0.2f);

                LeanTween.scale(healthIcon3, new Vector3(0.1f, 0.1f, 0.1f), 0.2f).setEase(easeType2);

                ease2 = false;
            }
        }
        else
        {
            ease2 = true;
        }

        if (value >= 3)
        {
            value = 3;

            if (ease3)
            {
                healthIcon1.GetComponent<Image>().sprite = fullHeart;
                healthIcon2.GetComponent<Image>().sprite = fullHeart;
                healthIcon3.GetComponent<Image>().sprite = fullHeart;

                LeanTween.scale(healthIcon3, new Vector3(0.2f, 0.2f, 0.2f), 0.2f).setEase(easeType);
                LeanTween.scale(healthIcon3, new Vector3(0.15f, 0.15f, 0.15f), 0.2f).setEase(easeType).setDelay(0.2f);

                ease3 = false;
            }
        }
        else
        {
            ease3 = true;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            value += 1;

            if (value <= 3)
                healSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            CancelInvoke();
            canIncrease = false;
            value -= decreaseValue;
            InvokeRepeating("Increase", 2, 2000);

            StartCoroutine(screenShake.Shake(0.15f, 0.2f));

            Rigidbody rb = player.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(150, other.transform.position, 5, 2.5f, ForceMode.Impulse);
            }
        }
    }

    void Increase()
    {
        canIncrease = true;
        CancelInvoke();
    }

    void GameOverScreen()
    {

    }
}
