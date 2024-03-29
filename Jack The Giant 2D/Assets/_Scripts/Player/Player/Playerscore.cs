﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscore : MonoBehaviour
{
	[SerializeField]
	private AudioClip coinClip, lifeClip, gameoverClip, dieClip;

	private CameraScript cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int lifeCount;
	public static int coinCount;
	public static int scoreCount;

	void Awake()
	{
		cameraScript = Camera.main.GetComponent<CameraScript>();
	}

	void Start()
	{
		previousPosition = transform.position;
		countScore = true;
	}

	void Update()
	{
		CountScore();
	}

	void CountScore()
	{
		if (countScore)
		{
			if (transform.position.y < previousPosition.y)
			{
				scoreCount++;
                GameplayController.instance.SetScore(scoreCount);
            }

			previousPosition = transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Coin")
		{
			coinCount++;
			scoreCount += 200;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, Camera.main.transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Life")
		{
			lifeCount++;
			scoreCount += 300;

            GameplayController.instance.SetLifeScore(lifeCount);
            GameplayController.instance.SetScore(scoreCount);

            AudioSource.PlayClipAtPoint(lifeClip, Camera.main.transform.position);
			target.gameObject.SetActive(false);
		}

		if (target.tag == "Bounds" || target.tag == "Dadly")
		{
			cameraScript.moveCamera = false;
			countScore = false;
			transform.position = new Vector3(500, 500, 0);
			lifeCount--;
			AudioSource.PlayClipAtPoint(dieClip, Camera.main.transform.position);

			GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
		}

		//if (target.tag == "Dadly")
		//{
		//	cameraScript.moveCamera = false;
		//	countScore = false;
		//	transform.position = new Vector3(500, 500, 0);
		//	lifeCount--;

			
			//GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
		//}
	}
}
