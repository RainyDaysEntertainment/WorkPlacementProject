using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    public Vector3 position;

    private void Start()
    {
        transform.position = position;
    }
}
