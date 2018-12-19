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
	public AudioSource seleccionMenu;

    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
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
					seleccionMenu.Play();
					ComenzarPartidaSolo.jugador = jugadorWeabooLord;
					nombreEscena = "PartidaSolo";
					LoadScene();
				}
				else if (hit.transform.name == "ItguyLord")
				{
					seleccionMenu.Play();
					ComenzarPartidaSolo.jugador = jugadorItguyLord;
					nombreEscena = "PartidaSolo";
					LoadScene();
				}
				else if (hit.transform.name == "EmoLord")
				{
					seleccionMenu.Play();
					ComenzarPartidaSolo.jugador = jugadorEmoLord;
					nombreEscena = "PartidaSolo";
					LoadScene();
				} else if(hit.transform.name=="Salir")
                {
					seleccionMenu.Play();
					nombreEscena = "MenuPrincipal";
                    LoadScene();
                }
			}
		}
	}
}
