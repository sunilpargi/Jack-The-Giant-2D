﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    private GameObject[] backgrounds;

    private float lastY;
    void Start()
    {
        GetbackgroundAndSetlastPosY();
    }

    private void GetbackgroundAndSetlastPosY()
    {
        backgrounds = GameObject.FindGameObjectsWithTag("BG");

        lastY = backgrounds[0].transform.position.y;

        for (int i = 1; i < backgrounds.Length; i++)
        {
            if(lastY > backgrounds[i].transform.position.y)
            {
                lastY = backgrounds[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("BG"))
        {
            if(target.transform.position.y == lastY)
            {
                
                Vector3 temp = target.transform.position;
                float height = ((BoxCollider2D)target).size.y;
              

                for (int i = 0; i < backgrounds.Length; i++)
                {
                   
                    if (!backgrounds[i].activeInHierarchy)
                    {
                       
                        temp.y -= height;

                        lastY = temp.y;

                        backgrounds[i].transform.position = temp;
                        backgrounds[i].SetActive(true);
                       
                    }
                }
            }
        }
    }
}
