using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleNameScript : MonoBehaviour
{
    Color colour;
    public bool lerping;

    void OnEnable()
    {
        Invoke("StartLerp", 0.5f);
    }

    void Update()
    {
        if (lerping)
        {
            gameObject.GetComponent<Image>().color = Color.Lerp(
                gameObject.GetComponent<Image>().color,
                new Color(1, 1, 1, 1), Time.deltaTime * 0.75f);
        }

        if (gameObject.GetComponent<Image>().color == new Color(1, 1, 1, 0.99f))
        {
            lerping = false;
        }
    }

    void StartLerp()
    {
        lerping = true;
        CancelInvoke();
    }
}
