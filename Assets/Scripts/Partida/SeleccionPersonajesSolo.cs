using Assets.Scripts.ServidorDTO;
using Assets.Servidor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionPersonajesSolo : MonoBehaviour
{
	private string nombreEscena;
	public GameObject transicion;
	public GameObject jugadorWeabooLord;
	public GameObject jugadorItguyLord;
	public GameObject jugadorEmoLord;
	public AudioSource seleccionMenu;
	public GameObject weabooCarta1;
	public GameObject weabooCarta2;
	public GameObject weabooCarta3;
	public GameObject itGuyCarta1;
	public GameObject itGuyCarta2;
	public GameObject itGuyCarta3;
	public GameObject emoCarta1;
	public GameObject emoCarta2;
	public GameObject emoCarta3;
	private bool infoLoaded;


	private void Start()
	{
		infoLoaded = false;
		CargarCartas();
	}

	void LoadScene()
	{
		//Transicion.nombreEscena = nombreEscena;
		//transicion.GetComponent<Animator>().SetTrigger("Cerrar");
		SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);

	}

	private void CargarCartas()
	{
		List<Assets.Scripts.ServidorDTO.Carta> cartas = ManejadorUsuario.cartasUsuario;
		for (int i = 0; i < cartas.Count; i++)
		{
			Assets.Scripts.ServidorDTO.Carta carta = cartas[i];
			//GameObject nuevoSprite = (GameObject)Instantiate(weabooCarta1);
			Debug.Log(carta.ToString());
			Sprite sprite = Resources.Load<Sprite>("Sprites/Partida/MostrarCartas/" + carta.ToString());
			GameObject cartaACargar = null;
			if(carta.tipo.Equals("nerd-weabooLord") && carta.nombre.Equals("catapulta"))
			{
				cartaACargar = weabooCarta1;
			}
			else if (carta.tipo.Equals("nerd-weabooLord") && carta.nombre.Equals("mochila_pegajosa"))
			{
				cartaACargar = weabooCarta2;
			}
			else if (carta.tipo.Equals("nerd-weabooLord") && carta.nombre.Equals("dakimakura"))
			{
				cartaACargar = weabooCarta3;
			}
			else if (carta.tipo.Equals("nerd-it-guy") && carta.nombre.Equals("drone_idle"))
			{
				cartaACargar = itGuyCarta1;
			}
			else if (carta.tipo.Equals("nerd-it-guy") && carta.nombre.Equals("Drone_2_Idle"))
			{
				cartaACargar = itGuyCarta2;
			}
			else if (carta.tipo.Equals("nerd-it-guy") && carta.nombre.Equals("Drone_3_Idle"))
			{
				cartaACargar = itGuyCarta3;
			}
			else if (carta.tipo.Equals("nerd-punk-girl") && carta.nombre.Equals("mochila_cierra"))
			{
				cartaACargar = emoCarta1;
			}
			else if (carta.tipo.Equals("nerd-punk-girl") && carta.nombre.Equals("mochila_mina"))
			{
				cartaACargar = emoCarta2;
			}
			else if (carta.tipo.Equals("nerd-punk-girl") && carta.nombre.Equals("mochila_honda"))
			{
				cartaACargar = emoCarta3;
			}
			if (cartaACargar != null)
			{
				SpriteRenderer renderer = cartaACargar.GetComponent<SpriteRenderer>();
				renderer.sprite = sprite;
				cartaACargar.name = carta.ToString();
			}
			
		}
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
					Debug.Log("WEABOO");
					seleccionMenu.Play();
					ComenzarPartidaSolo.jugador = jugadorWeabooLord;
					nombreEscena = "LoadingSolo";
					LoadScene();
				}
				else if (hit.transform.name == "ItguyLord")
				{
					Debug.Log("it");
					seleccionMenu.Play();
					ComenzarPartidaSolo.jugador = jugadorItguyLord;
					nombreEscena = "LoadingSolo";
					LoadScene();
				}
				else if (hit.transform.name == "EmoLord")
				{
					Debug.Log("emo");
					seleccionMenu.Play();
					ComenzarPartidaSolo.jugador = jugadorEmoLord;
					nombreEscena = "LoadingSolo";
					LoadScene();
				} else if(hit.transform.name=="Salir")
                {
					seleccionMenu.Play();
					nombreEscena = "Camino";
                    LoadScene();
                }
			}
		}
	}
}
