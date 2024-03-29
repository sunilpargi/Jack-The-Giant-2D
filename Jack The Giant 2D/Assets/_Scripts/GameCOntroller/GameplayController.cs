﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, lifeScore, coinScore, gameOverScoreText, gameOverCoinScoreText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

	public AudioClip gameStartClip, uITouchClick;
	void Awake()
	{
		MakeInstance();
				Time.timeScale = 0f;
	}

	void Start()
	{
		Time.timeScale = 0f;
	}

	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	public void SetScore(int score)
	{
		scoreText.text = "" + score;
	}

	public void SetCoinScore(int score)
	{
		coinScore.text = "x" + score;
	}

	public void SetLifeScore(int score)
	{
		lifeScore.text = "x" + score;
	}

	public void GameOverShowPanel(int gameOverScore, int gameOverCoinScore)
	{
		gameOverPanel.SetActive(true);
		gameOverScoreText.text = "" + gameOverScore;
		gameOverCoinScoreText.text = "" + gameOverCoinScore;
		StartCoroutine(GameOverLoadMainMenu());
	}

	IEnumerator GameOverLoadMainMenu()
	{
		yield return new WaitForSeconds(3f);
		//SceneManager.LoadScene("MainMenu");
		SceneFader.instance.LoadLevel("MainMenu");
	}

	public void PlayerDiedRestartLevel()
	{
		StartCoroutine(PlayerDiedRestart());
	}

	IEnumerator PlayerDiedRestart()
	{
		yield return new WaitForSeconds(3f);
		//SceneManager.LoadScene("Gameplay"); 
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void PauseGame()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void ResumeGame()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void QuitGame()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		Time.timeScale = 1f;
		//SceneManager.LoadScene ("MainMenu");
		SceneFader.instance.LoadLevel ("MainMenu");
	}

	public void StartTheGame()
	{
		Time.timeScale = 1f;
		AudioSource.PlayClipAtPoint(gameStartClip, Camera.main.transform.position);
		readyButton.SetActive(false);
	}


}
