using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float value;
    float increaseValue = 0.05f, decreaseValue = 0.5f;

    [HideInInspector]
    public bool canIncrease = true;
    
    GameObject player, healthSlider;

    void Start()
    {
        player = GameObject.Find("Player");
        healthSlider = GameObject.Find("HealthSlider");
        
        value = healthSlider.GetComponent<Slider>().maxValue;
    }
    
    void Update()
    {
        healthSlider.GetComponent<Slider>().value = value;

        //if (value < healthSlider.GetComponent<Slider>().maxValue && canIncrease && Time.timeScale != 0)
        //{
        //    value += increaseValue;
        //}

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
        }
    }

    void Increase()
    {
        canIncrease = true;
        CancelInvoke();
    }
}
