using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float value;
    float increaseValue = 0.05f, decreaseValue = 0.5f;

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

        value = player.GetComponent<PlayerVariables>().health;
        screenShake = GameObject.Find("Camera").GetComponent<ScreenShake>();
    }

    void Update()
    {
        //healthSlider.GetComponent<Slider>().value = value;

        //if (value < healthSlider.GetComponent<Slider>().maxValue && canIncrease && Time.timeScale != 0)
        //{
        //    value += increaseValue;
        //}
         
        switch (value)
        {
            case 0:
                healthIcon1.GetComponent<Image>().sprite = emptyHealth;
                healthIcon2.GetComponent<Image>().sprite = emptyHealth;
                healthIcon3.GetComponent<Image>().sprite = emptyHealth;

                LeanTween.scale(healthIcon1, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setLoopOnce().setEase(shrinkEaseType);
                LeanTween.scale(healthIcon2, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setLoopOnce().setEase(shrinkEaseType);
                LeanTween.scale(healthIcon3, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setLoopOnce().setEase(shrinkEaseType);
                break;

            case 1:
                healthIcon1.GetComponent<Image>().sprite = fullHealth;
                healthIcon2.GetComponent<Image>().sprite = emptyHealth;
                healthIcon3.GetComponent<Image>().sprite = emptyHealth;

                LeanTween.scale(healthIcon2, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType).setRepeat(1);
                LeanTween.scale(healthIcon3, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType).setRepeat(1);

                LeanTween.scale(healthIcon1, new Vector3(1.2f, 1.2f, 1.2f), 0.4f).setEase(expandEaseType).setRepeat(1);
                LeanTween.scale(healthIcon1, new Vector3(1, 1, 1), 0.4f).setDelay(0.4f).setEase(shrinkEaseType);
                break;

            case 2:
                healthIcon1.GetComponent<Image>().sprite = fullHealth;
                healthIcon2.GetComponent<Image>().sprite = fullHealth;
                healthIcon3.GetComponent<Image>().sprite = emptyHealth;

                LeanTween.scale(healthIcon3, new Vector3(0.8f, 0.8f, 0.8f), 0.2f).setEase(shrinkEaseType).setLoopCount(0);

                healthIcon1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                LeanTween.scale(healthIcon2, new Vector3(1.2f, 1.2f, 1.2f), 0.4f).setEase(expandEaseType).setLoopCount(0);
                LeanTween.scale(healthIcon2, new Vector3(1, 1, 1), 0.4f).setDelay(0.4f).setEase(shrinkEaseType);
                break;

            case 3:
                healthIcon1.GetComponent<Image>().sprite = fullHealth;
                healthIcon2.GetComponent<Image>().sprite = fullHealth;
                healthIcon3.GetComponent<Image>().sprite = fullHealth;

                healthIcon1.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                healthIcon2.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

                LeanTween.scale(healthIcon3, new Vector3(1.2f, 1.2f, 1.2f), 0.4f).setLoopOnce().setEase(expandEaseType);
                LeanTween.scale(healthIcon3, new Vector3(1, 1, 1), 0.4f).setDelay(0.4f).setLoopOnce();
                break;
        }

        if (value >= 3)
        {
            value = 3;
        }

        if (value <= 0)
        {
            value = 0;
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
}
