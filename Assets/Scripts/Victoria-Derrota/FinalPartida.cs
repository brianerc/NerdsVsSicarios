using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MonoBehaviour correspondiente a la escena de final de partida
/// </summary>
abstract public class FinalPartida : MonoBehaviour {

	void Start () {
	}

    void Update()
    {
        if (Input.touchCount < 1)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (touch.phase == TouchPhase.Ended)
        {
            SceneManager.LoadScene("MenuPrincipal",LoadSceneMode.Single);
        }
    }
}
