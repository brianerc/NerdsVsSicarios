using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSolo : MonoBehaviour
{
	private bool loaded;

	private void Start()
	{
		loaded = false;
	}

	private void Update()
	{
		if (!loaded)
		{
			loaded = true;
			LoadScene();
		}
	}

		private void LoadScene()
	{
		StartCoroutine(LoadYourAsyncScene());
	}

	IEnumerator LoadYourAsyncScene()
	{
		
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PartidaSolo");
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
