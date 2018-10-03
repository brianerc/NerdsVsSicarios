using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
abstract public class FinalPartida : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
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
