using Assets.Scripts.ServidorDTO;
using Assets.Servidor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelesCartas : MonoBehaviour
{

	//public Text error;

	void Start()
	{
		//error.text = "";
		SubirDeNivelCarta("asd");
	}

	public void SubirDeNivelCarta(string idCarta)
	{
		StartCoroutine(SubirDeNivelCartaRoutine(idCarta));
	}

	public IEnumerator SubirDeNivelCartaRoutine(string idCarta)
	{
		WWW www = Acciones.SubirDeNivelCarta(idCarta);
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			//error.text = www.error;
			//error.color = Color.red;
			//if (error.text.Equals("400 Bad Request"))
			//{
			//	error.text = "Card can't level up more";
			//}
			//else
			//{
			//	error.text = "Error on server";
			//}
			Debug.Log(www.error);
			Debug.Log("EN ERROR SubirDeNivelCartaRoutine");
		}
		else
		{
			//Devuelve nuevamente las cartas del usuario actualizada con el nivel subido
			CartaDTO resultObj = JsonUtility.FromJson<CartaDTO>(www.text);
			for (int i = 0; i < resultObj.cartas.Count; i++)
			{
				Assets.Scripts.ServidorDTO.Carta carta = resultObj.cartas[i];
				//Cargar nuevamente el scroll de cartas
				//GameObject newText = (GameObject)Instantiate(myTextPrefab);
				//newText.transform.SetParent(myPanel);
				//newText.GetComponent<Text>().text = carta.ToString();
				//myNumber++;
			}
		}
	}
}
