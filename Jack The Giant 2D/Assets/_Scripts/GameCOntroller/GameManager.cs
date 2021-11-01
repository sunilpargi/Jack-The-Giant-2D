using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[HideInInspector]
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	[HideInInspector]
	public int score, coinScore, lifeScore;
	public AudioClip gameoverClip;
	void Awake()
	{
		MakeSingleton();
	}

	void Start()
	{
		InitializeGame();
	}

	void MakeSingleton()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	void InitializeGame()
	{
		if (!PlayerPrefs.HasKey("Game Initialized"))
		{
			GamePreferences.SetMusicState(1);

			GamePreferences.SetEasyDifficultyState(1);
			GamePreferences.SetEasyDifficultyHighscore(0);
			GamePreferences.SetEasyDifficultyCoinScore(0);

			GamePreferences.SetMediumDifficultyState(0);
			GamePreferences.SetMediumDifficultyHighscore(0);
			GamePreferences.SetMediumDifficultyCoinScore(0);

			GamePreferences.SetHardDifficultyState(1);
			GamePreferences.SetHardDifficultyHighscore(0);
			GamePreferences.SetHardDifficultyCoinScore(0);

			PlayerPrefs.SetInt("Game Initialized", 0);
		}
	}
	private void OnEnable()
    {
		SceneManager.sceneLoaded += OnSceneLoaded;
    }

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}


	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(scene.name == "Gameplay")
        {
			if (gameRestartedAfterPlayerDied)
			{
				GameplayController.instance.SetScore(score);
				GameplayController.instance.SetLifeScore(lifeScore);
				GameplayController.instance.SetCoinScore(coinScore);

				Playerscore.coinCount = coinScore;
				Playerscore.scoreCount = score;
				Playerscore.lifeCount = lifeScore;

			}
			else if (gameStartedFromMainMenu)
			{
				Playerscore.coinCount = 0;
				Playerscore.scoreCount = 0;
				Playerscore.lifeCount = 2;

				GameplayController.instance.SetScore(0);
				GameplayController.instance.SetLifeScore(2);
				GameplayController.instance.SetCoinScore(0);

			}
		}
	}
	public void CheckGameStatus(int score, int coinScore, int lifeScore)
	{
		if (lifeScore < 0)
		{
			AudioSource.PlayClipAtPoint(gameoverClip, Camera.main.transform.position);

			if (GamePreferences.GetEasyDifficultyState() == 0)
            {

                int highscore = GamePreferences.GetEasyDifficultyHighscore();
                int highCoinScore = GamePreferences.GetEasyDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetEasyDifficultyHighscore(score);

                if (highCoinScore < coinScore)
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);

            }

            if (GamePreferences.GetMediumDifficultyState() == 0)
            {

                int highscore = GamePreferences.GetMediumDifficultyHighscore();
                int highCoinScore = GamePreferences.GetMediumDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetMediumDifficultyHighscore(score);

                if (highCoinScore < coinScore)
                    GamePreferences.SetMediumDifficultyCoinScore(coinScore);

            }

            if (GamePreferences.GetHardDifficultyState() == 0)
            {

                int highscore = GamePreferences.GetHardDifficultyHighscore();
                int highCoinScore = GamePreferences.GetHardDifficultyCoinScore();

                if (highscore < score)
                    GamePreferences.SetHardDifficultyHighscore(score);

                if (highCoinScore < coinScore)
                    GamePreferences.SetHardDifficultyCoinScore(coinScore);

            }

            gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = false;

			GameplayController.instance.GameOverShowPanel(score, coinScore);

		}
		else
		{

			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

		

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = true;

			GameplayController.instance.PlayerDiedRestartLevel();

		}
	}

}
