using Assets.Servidor;
using Assets.Servidor.ServidorDTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

	public Text error;

	void Start()
	{
		error.text = "";
	}

	public void SubirDeNivelJugador()
	{
		StartCoroutine(SubirDeNivelCartaRoutine());
	}

	public IEnumerator SubirDeNivelCartaRoutine()
	{
		WWW www = Acciones.SubirDeNivel();
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			error.text = www.error;
			error.color = Color.red;
			error.text = "Error on server";
			Debug.Log(www.error);
			Debug.Log("EN ERROR");
		}
		else
		{
			//Devuelve el usuario con su nivel actualizado 
			UsuarioDTO resultObj = JsonUtility.FromJson<UsuarioDTO>(www.text);
		}
	}
}
