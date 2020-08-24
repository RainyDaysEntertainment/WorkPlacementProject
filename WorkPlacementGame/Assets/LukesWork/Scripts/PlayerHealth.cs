using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float hValue;
    float decreaseValue = 1f;

    [HideInInspector]
    public bool canIncrease = true;

    GameObject player, healthSlider;

    public ScreenShake screenShake;

    public GameObject healthIcon1, healthIcon2, healthIcon3;
    public Sprite fullHealth, emptyHealth;

    public LeanTweenType shrinkEaseType, expandEaseType;

    void Start()
    {
        player = GameObject.Find("Player");
        healthSlider = GameObject.Find("HealthSlider");

        hValue = player.GetComponent<PlayerVariables>().health;
        screenShake = GameObject.Find("Camera").GetComponent<ScreenShake>();
    }

    void Update()
    {
        //healthSlider.GetComponent<Slider>().value = value;

        //if (value < healthSlider.GetComponent<Slider>().maxValue && canIncrease && Time.timeScale != 0)
        //{
        //    value += increaseValue;
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            Value += 1;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Value -= 1;
        }

        if (hValue >= 3)
        {
            hValue = 3;
        }

        if (hValue <= 0)
        {
            hValue = 0;
        }
    }

    public float Value
    {
        get { return hValue; }
        set
        {
            if (value == hValue)
                return;

            hValue = value;


            switch (hValue)
            {
                case 0:
                    healthIcon1.GetComponent<Image>().sprite = emptyHealth;
                    healthIcon2.GetComponent<Image>().sprite = emptyHealth;
                    healthIcon3.GetComponent<Image>().sprite = emptyHealth;

                    LeanTween.scale(healthIcon1, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType);
                    LeanTween.scale(healthIcon2, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType);
                    LeanTween.scale(healthIcon3, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType);
                    break;

                case 1:
                    healthIcon1.GetComponent<Image>().sprite = fullHealth;
                    healthIcon2.GetComponent<Image>().sprite = emptyHealth;
                    healthIcon3.GetComponent<Image>().sprite = emptyHealth;

                    LeanTween.scale(healthIcon2, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType);
                    LeanTween.scale(healthIcon3, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType);

                    LeanTween.scale(healthIcon1, new Vector3(1.3f, 1.3f, 1.3f), 0.4f).setEase(expandEaseType);
                    LeanTween.scale(healthIcon1, new Vector3(1, 1, 1), 0.2f).setDelay(0.4f).setEase(shrinkEaseType);
                    break;

                case 2:
                    healthIcon1.GetComponent<Image>().sprite = fullHealth;
                    healthIcon2.GetComponent<Image>().sprite = fullHealth;
                    healthIcon3.GetComponent<Image>().sprite = emptyHealth;

                    LeanTween.scale(healthIcon3, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType);

                    //healthIcon1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                    LeanTween.scale(healthIcon2, new Vector3(1.3f, 1.3f, 1.3f), 0.4f).setEase(expandEaseType);
                    LeanTween.scale(healthIcon2, new Vector3(1, 1, 1), 0.2f).setDelay(0.4f).setEase(shrinkEaseType);
                    break;

                case 3:
                    healthIcon1.GetComponent<Image>().sprite = fullHealth;
                    healthIcon2.GetComponent<Image>().sprite = fullHealth;
                    healthIcon3.GetComponent<Image>().sprite = fullHealth;

                    //healthIcon1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                    //healthIcon2.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                    LeanTween.scale(healthIcon3, new Vector3(1.3f, 1.3f, 1.3f), 0.4f).setEase(expandEaseType);
                    LeanTween.scale(healthIcon3, new Vector3(1, 1, 1), 0.2f).setDelay(0.4f);
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            CancelInvoke();
            canIncrease = false;
            Value -= decreaseValue;
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
}
