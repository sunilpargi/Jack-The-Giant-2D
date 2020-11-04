﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private float distancebetweenCloud = 3f;

    private float minX, maxX;

    private float lastCloudPositonY;

    private float controlX;

    [SerializeField]
    private GameObject[] collectbles;

    private GameObject player;
    void Awake()
    {
        controlX = 0;
        SetMinAndMax();
        CreateClouds();
    }

   

    private void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }

    void suffle(GameObject[] arrayToSuffle)
    {
        for(int i = 0; i < arrayToSuffle.Length; i++)
        {
            GameObject temp = arrayToSuffle[i];
            int random = UnityEngine.Random.Range(0, arrayToSuffle.Length);
            arrayToSuffle[i] = arrayToSuffle[random];
            arrayToSuffle[random] = temp; 
        }
    }

    private void CreateClouds()
    {
        suffle(clouds);

        float positionY = 0;

        for(int i = 0; i< clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;

          
            temp.y = positionY;

            if(controlX == 0)
            {
                temp.x = UnityEngine.Random.Range(0f, maxX);
                controlX = 1;
            }
          else if (controlX == 1)
            {
                temp.x = UnityEngine.Random.Range(0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = UnityEngine.Random.Range(1f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = UnityEngine.Random.Range(-1f, minX);
                controlX = 0;
            }


            lastCloudPositonY = positionY;

            clouds[i].transform.position = temp; 

            positionY -= distancebetweenCloud;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}