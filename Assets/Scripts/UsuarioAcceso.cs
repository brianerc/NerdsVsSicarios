using Assets.Scripts.Partida;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class UsuarioAcceso : MonoBehaviour
{

	public InputField textNombreDeUsuario;
	public InputField contrasenia;
	public Text error;


	public void crearUsuario()
	{

		string nombreDeUsuario = textNombreDeUsuario.text;
		string contraseniaTexto = contrasenia.text;
		StartCoroutine(POST(nombreDeUsuario, contraseniaTexto));

	}

	public IEnumerator POST(string nombreDeUsuario, string contrasenia)
	{
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");

		string postBodyData = "{\"nombreusuario\":\"" + nombreDeUsuario + "\" , \"contrasenia\": \"" + contrasenia + "\"}";

		byte[] pData = System.Text.Encoding.ASCII.GetBytes(postBodyData.ToCharArray());

		WWW www = new WWW("http://35.225.13.246:8090/api/v1/usuario", pData, headers);

		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			error.text = www.error;
			if (string.IsNullOrEmpty(error.text))
			{
				error.color = Color.green;
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
			}
		}
	}
}
