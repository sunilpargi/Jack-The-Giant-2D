﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	// Start is called before the first frame update
	public void PlayGame()
	{
		
		SceneManager.LoadScene("Gameplay");
	}

	public void HighScoreMenu()
	{
		SceneManager.LoadScene("Highscore");
	}

	public void OptionsMenu()
	{
		SceneManager.LoadScene("OptionMenu");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
