using Assets.Scripts.Partida;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Assets.Scripts.ServidorDTO;
using UnityEngine.SceneManagement;
using Assets.Servidor;

public class UsuarioAcceso : MonoBehaviour
{
    public GameObject transicion;
	public InputField textNombreDeUsuario;
	public InputField contrasenia;
	public Text error;
	public Button boton;
    private string nombreEscena;
	public AudioSource sonidoSeleccion;

	public void Start()
	{
		string token = PlayerPrefs.GetString("token");
		if (token != null && !token.Equals(""))
		{
			Debug.Log("Existe token: " + token);
			SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
		}
		else
		{
			Debug.Log("No existe token");
		}
	}
    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    public void IrAEscenaRegistrarse()
	{
		sonidoSeleccion.Play();
		nombreEscena = "UsuarioRegistrar";
		LoadScene();
	}

	public void Ingresar()
	{
		sonidoSeleccion.Play();
		string nombreDeUsuario = textNombreDeUsuario.text;
		string contraseniaTexto = contrasenia.text;
		StartCoroutine(POST(nombreDeUsuario, contraseniaTexto));

	}

	public IEnumerator POST(string nombreDeUsuario, string contrasenia)
	{
		error.color = Color.black;
		error.text = "Cargando...";
		boton.enabled = false;

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
		boton.enabled = true;
	}
}
