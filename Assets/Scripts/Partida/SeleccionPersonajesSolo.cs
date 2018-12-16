using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionPersonajesSolo : MonoBehaviour
{
	private string nombreEscena;
	public GameObject transicion;
	public GameObject jugadorWeabooLord;
	public GameObject jugadorItguyLord;
	public GameObject jugadorEmoLord;


	IEnumerator LoadScene()
	{
		transicion.GetComponent<Animator>().SetTrigger("Cerrar");
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadSceneAsync(nombreEscena);
	}

	void Update()
	{
		
		RaycastHit2D hit;
		if (Input.touchCount < 1)
		{
			return;
		}
		Touch touch = Input.GetTouch(0);	
		Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
		hit = Physics2D.Raycast(test, (touch.position));
		if (touch.phase == TouchPhase.Ended)
		{
			if (hit.collider != null)
			{
				if (hit.transform.name == "WeabooLord")
				{
					ComenzarPartidaSolo.jugador = jugadorWeabooLord;
					nombreEscena = "PartidaSolo";
					StartCoroutine(LoadScene());
				}
				else if (hit.transform.name == "ItguyLord")
				{
					nombreEscena = "PartidaSolo";
					StartCoroutine(LoadScene());
				}
				else if (hit.transform.name == "EmoLord")
				{
					nombreEscena = "PartidaSolo";
					StartCoroutine(LoadScene());
				}
			}
		}
	}
}
