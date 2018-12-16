using Assets.Scripts.Partida;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BotonCrearUsuario : MonoBehaviour {

	public InputField textNombreDeUsuario;
	public InputField contrasenia;

	public void crearUsuario()
	{
		Debug.Log("PRESIONADO");
		string nombreDeUsuario = textNombreDeUsuario.text;
		string contraseniaTexto = contrasenia.text;
		StartCoroutine(POST(nombreDeUsuario, contraseniaTexto));

	}

	public IEnumerator POST(string nombreDeUsuario, string contrasenia)
	{
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		Jugador jugador = new Jugador(nombreDeUsuario, contrasenia);

		byte[] postData = Encoding.ASCII.GetBytes(JsonUtility.ToJson(jugador));

		WWW www = new WWW("35.225.13.246:8090/api/v1/usuario", postData, headers);

		yield return www;
		Debug.Log("Created a Post: " + www.text);
		jugador = JsonUtility.FromJson<Jugador>(www.text);
	}
}
