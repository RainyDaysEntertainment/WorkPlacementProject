﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsScript : MonoBehaviour
{
    GameObject player;

    public int verticalStackSize = 20;
    public float cloudSpacing;
    public Mesh quadMesh;
    public Material cloudMaterial;
    float offset;

    public int layer = 1;
    Camera camera;
    Matrix4x4 matrix;

    void Start()
    {
        player = GameObject.Find("Player");
        //camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        //quadMesh = GetComponent<Mesh>();
        //cloudMaterial = GetComponent<Material>();
    }

    void Update()
    {
        cloudMaterial.SetFloat("_midYValue", transform.position.y);
        cloudMaterial.SetFloat("_cloudHeight", cloudSpacing);

        offset = cloudSpacing / verticalStackSize / 2f;
        Vector3 startPosition = transform.position + (Vector3.up * (offset * verticalStackSize / 2f));

        for (int i = 0; i < verticalStackSize; i++)
        {
            matrix = Matrix4x4.TRS(startPosition - (Vector3.up * offset * i), transform.rotation, transform.localScale);
            Graphics.DrawMesh(quadMesh, matrix, cloudMaterial, layer, camera, 0, null, true, false, false);
        }

        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 100);
    }
}
