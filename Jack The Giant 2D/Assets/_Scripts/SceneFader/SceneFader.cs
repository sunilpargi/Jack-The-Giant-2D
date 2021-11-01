  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
	public static SceneFader instance;

	[SerializeField]
	private GameObject fader;

	[SerializeField]
	Animator fadeAnim;

	void Awake()
	{
		MakeInstance();
	}

	void MakeInstance()
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

	public void LoadLevel(string level)
	{
		StartCoroutine(FadeInOut(level));
	}

	IEnumerator FadeInOut(string level)
	{
		fader.SetActive(true);
		fadeAnim.Play("FadeIn");
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f)) ;
		SceneManager.LoadScene(level);

		fadeAnim.Play("FadeOut");
		yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(.7f));
		fader.SetActive(false);
	}
}
