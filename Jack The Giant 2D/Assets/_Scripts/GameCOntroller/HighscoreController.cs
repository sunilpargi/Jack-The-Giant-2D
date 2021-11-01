using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreController : MonoBehaviour
{

	[SerializeField]
	private Text scoreText, coinText;
	public AudioClip uITouchClick;
	void Start()
	{
		SetScoreForDifficulty();
	}

	public void SetScore(int score, int coin)
	{
		scoreText.text = "" + score;
		coinText.text = "" + coin;
	}

	void SetScoreForDifficulty()
	{
		if (GamePreferences.GetEasyDifficultyState() == 0)
		{
			SetScore(GamePreferences.GetEasyDifficultyHighscore(), GamePreferences.GetEasyDifficultyCoinScore());
		}

		if (GamePreferences.GetMediumDifficultyState() == 0)
		{
			SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinScore());
		}

		if (GamePreferences.GetHardDifficultyState() == 0)
		{
			SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinScore());
		}
	}

	public void GoBack()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		SceneManager.LoadScene("MainMenu");
    }
}
