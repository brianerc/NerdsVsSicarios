﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Servidor;
using Assets.Servidor.ServidorDTO;

public class MenuPrincipal : MonoBehaviour
{
	private string nombreEscena;
	public GameObject transicion;
	private bool primeraPrueba = false;

	void Start()
	{
		string token = PlayerPrefs.GetString("token");
		if (token == null || token.Equals(""))
		{
			Debug.Log("Existe token, validandolo...");
			SceneManager.LoadScene("UsuarioAcceso", LoadSceneMode.Single);
		}
		else
		{
			StartCoroutine(ManejadorUsuario.CargarUsuario());

			//Borrar despues de leer
			StartCoroutine(CambiarPuntos(20));
		}
	}

	//Borrar despues de leer
	public IEnumerator CambiarPuntos(int puntos)
	{
		WWW www = Acciones.SubirDeNivelCarta("5c16db52c3dad600331c49dd");
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			Debug.Log(www.error);
			Debug.Log("EN ERROR");
		}
		else
		{
			Debug.Log("EXITO: ");
			Debug.Log(www.text);
		}
	}

	private void LoadScene()
	{
		transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        Transicion.nombreEscena = nombreEscena;
	}

	/// <summary>
	/// Logica correspondiente a las seleccion de las distintas opciones del menu principal
	/// </summary>
	void Update()
	{
		Usuario usuario = ManejadorUsuario.ObtenerUsuario();
		if (usuario != null)
		{
			Debug.Log(usuario._id);
			//if (!primeraPrueba)
			//{
			//	primeraPrueba = true;
			//	NivelesCartas niv = new NivelesCartas();
			//	niv.SubirDeNivelCarta(usuario.cartas[0]._id);
			//}
		}
		RaycastHit2D hit;
		if (Input.touchCount < 1)
		{
			return;
		}
		Touch touch = Input.GetTouch(0);
		// Ray ray = Camera.main.ScreenPointToRay(touch.position);
		Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
		hit = Physics2D.Raycast(test, (touch.position));
		if (touch.phase == TouchPhase.Ended)
		{
			if (hit.collider != null)
			{
				if (hit.transform.tag == "Jugar")
				{
					nombreEscena = "Partida";
					LoadScene();
				}
				else if (hit.transform.tag == "Opciones")
				{

				}
				else if (hit.transform.tag == "JugarSolo")
				{
					Debug.Log("Jugar solo...");
					nombreEscena = "Camino";
					LoadScene();
				}
				else if (hit.transform.tag == "Cartas")
				{
					nombreEscena = "Cartas";
					LoadScene();
				}
				else if (hit.transform.tag == "Salir")
				{
					PlayerPrefs.SetString("token", "");
					nombreEscena = "UsuarioAcceso";
					LoadScene();
				}
			}
		}
	}
}