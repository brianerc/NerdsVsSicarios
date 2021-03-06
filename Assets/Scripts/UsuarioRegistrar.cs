﻿using Assets.Scripts.Partida;
using Assets.Servidor;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UsuarioRegistrar : MonoBehaviour
{
    public GameObject transicion;
	public InputField textNombreDeUsuario;
	public InputField contrasenia;
	public InputField contraseniaRepetir;
	public Text error;
	public Button boton;
    private string nombreEscena;
	public AudioSource seleccionMenu;

    private void Start()
    {
    }

    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    public void volver()
	{
		seleccionMenu.Play();
		nombreEscena = "UsuarioAcceso";
		LoadScene();
	}

	public void CrearUsuario()
	{
		seleccionMenu.Play();
		string nombreDeUsuario = textNombreDeUsuario.text;
		string contraseniaTexto = contrasenia.text;
		string contraseniaRepetirTexto = contraseniaRepetir.text;
		if (!contraseniaTexto.Equals(contraseniaRepetirTexto))
		{
			error.color = Color.red;
			error.text = "Contraseñas no coinciden";
		}
		else
		{
			StartCoroutine(IngresarUsuario(nombreDeUsuario, contraseniaTexto));
		}

	}

	public IEnumerator IngresarUsuario(string nombreDeUsuario, string contrasenia)
	{

		error.color = Color.black;
		error.text = "Cargando...";
		boton.interactable = false;
		WWW www = Acciones.CrearUsuario(nombreDeUsuario, contrasenia);
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			error.text = www.error;
			error.color = Color.red;
			if (error.text.Equals("400 Bad Request"))
			{
				error.text = "Usuario ya existe";
			}
			else
			{
				error.text = "Error con el servidor";
			}
			Debug.Log(www.error);
			Debug.Log("EN ERROR");
			boton.interactable = true;
		}
		else
		{
			error.color = Color.green;
			error.text = "Usuario creado";
			yield return IngresarConUsuarioYCotnrasenia(nombreDeUsuario, contrasenia);
		}
	}

	private IEnumerator IngresarConUsuarioYCotnrasenia(string nombreDeUsuario, string contrasenia)
	{
		WWW www = Acciones.IngresarConUsuario(nombreDeUsuario, contrasenia);

		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			error.text = www.error;
			error.color = Color.red;
			if (error.text.Equals("400 Bad Request") || error.text.Equals("404 Not Found"))
			{
				error.text = "Usuario o contraseña incorrecta";
			}
			else
			{
				error.text = "Error con el servidor";
			}
			Debug.Log(www.error);
			Debug.Log("EN ERROR");
		}
		else
		{
			string token = www.text;
			Debug.Log("Token: " + token);
			//var resultObj = JsonUtility.FromJson<Autenticacion>(token);
			if (token != null && !token.Equals(""))
			{
				PlayerPrefs.SetString("token", token);
				error.color = Color.green;
				error.text = "Usuario ingresado";
				nombreEscena = "MenuPrincipal";
				LoadScene();
			}
		}
		boton.interactable = true;
	}

}
