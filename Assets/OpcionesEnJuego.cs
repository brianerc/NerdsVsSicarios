using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcionesEnJuego : MonoBehaviour
{
	private string nombreEscena;
	public GameObject transicion;
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
				if (hit.collider.tag == "VolverMenuPrincipal" || hit.transform.name == "VolverMenuPrincipal")
				{
					nombreEscena = "MenuPrincipal";
					LoadScene();
				}
			}
		}
	}

	private void LoadScene()
	{
		Transicion.nombreEscena = nombreEscena;
		transicion.GetComponent<Animator>().SetTrigger("Cerrar");
	}
}
