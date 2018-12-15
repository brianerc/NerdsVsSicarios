using Assets.Scripts.Partida;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Servidor;
using System;

public class UsuarioRegistrar : MonoBehaviour
{
    public GameObject transicion;
	public InputField textNombreDeUsuario;
	public InputField contrasenia;
	public Text error;
	public Button boton;
    private string nombreEscena;

    private void Start()
    {
    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }
    public void volver()
	{
        nombreEscena = "UsuarioAcceso";
        StartCoroutine(LoadScene());
    }
    
	public void crearUsuario()
	{

		string nombreDeUsuario = textNombreDeUsuario.text;
		string contraseniaTexto = contrasenia.text;
		StartCoroutine(POST(nombreDeUsuario, contraseniaTexto));
	}

	public IEnumerator POST(string nombreDeUsuario, string contrasenia)
	{
		error.color = Color.black;
		error.text = "Cargando...";
		boton.enabled = false;
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
		}
		else
		{
			error.color = Color.green;
			error.text = "Usuario creado";
			yield return IngresarConUsuarioYCotnrasenia(nombreDeUsuario, contrasenia);
		}
		boton.enabled = true;
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
				StartCoroutine(LoadScene());
			}
		}
	}
}
