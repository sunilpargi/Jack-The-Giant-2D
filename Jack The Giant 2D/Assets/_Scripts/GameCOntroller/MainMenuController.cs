using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	[SerializeField]
	private Button musicButton;

	[SerializeField]
	private Sprite[] musicIcons;
	public AudioClip uITouchClick;
	void Start()
	{
		CheckIfMusicIsOnOrOff();
	}

	void CheckIfMusicIsOnOrOff()
	{
		if (GamePreferences.GetMusicState() == 0)
		{
			if (AudioController.instance != null)
			{
				AudioController.instance.PlayMusic(true);
			}
			musicButton.image.sprite = musicIcons[0];
		}
		else
		{
			musicButton.image.sprite = musicIcons[1];
		}
		
	}
	public void PlayGame()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		GameManager.instance.gameStartedFromMainMenu = true;
		//SceneManager.LoadScene("Gameplay");
		SceneFader.instance.LoadLevel("Gameplay");
	}

	public void HighScoreMenu()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		SceneManager.LoadScene("Highscore");
	}

	public void OptionsMenu()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		SceneManager.LoadScene("OptionMenu");
	}

	public void QuitGame()
	{
		AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		Application.Quit();


	}

	public void TurnMusicOnOrOff()
	{
		if (GamePreferences.GetMusicState() == 0)
		{
			GamePreferences.SetMusicState(1);
			if (AudioController.instance != null)
			{
				AudioController.instance.PlayMusic(false);
			}
			musicButton.image.sprite = musicIcons[1];
			AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		}
		else
		{
			GamePreferences.SetMusicState(0);
			if (AudioController.instance != null)
			{
				AudioController.instance.PlayMusic(true);
			}
			musicButton.image.sprite = musicIcons[0];
			AudioSource.PlayClipAtPoint(uITouchClick, Camera.main.transform.position);
		}
	}
}
