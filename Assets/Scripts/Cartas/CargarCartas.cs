using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.ServidorDTO;
using Assets.Servidor;

public class CargarCartas : MonoBehaviour
{

	public RectTransform myPanel;
	public GameObject myTextPrefab;
	private int myNumber = 0;
	private GameObject newText;
	public Text error;

	// Use this for initialization
	void Start()
	{
		error.text = "";
		//nextMessage = Time.time + 1f;
		StartCoroutine(ObtenerCartas());

	}
	// Update is called once per frame
	void Update()
	{
	}

	public IEnumerator ObtenerCartas()
	{
		WWW www = Acciones.CargarCartas();
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			error.text = www.error;
			error.color = Color.red;
			if (error.text.Equals("400 Bad Request"))
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
			CartaDTO resultObj = JsonUtility.FromJson<CartaDTO>(www.text);
			for (int i = 0; i < resultObj.cartas.Count; i++)
			{
				Assets.Scripts.ServidorDTO.Carta carta = resultObj.cartas[i];
				GameObject newText = (GameObject)Instantiate(myTextPrefab);
				newText.transform.SetParent(myPanel);
				newText.GetComponent<Text>().text = carta.ToString();
				myNumber++;
			}
		}
	}

	public void volverAlMenuPrincipal()
	{
		SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
	}

}
