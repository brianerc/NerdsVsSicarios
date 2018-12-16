using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.ServidorDTO;

public class CargarCartas : MonoBehaviour
{

	public RectTransform miPanel;
	public GameObject spritePrefab;
	private int miNumero = 0;
	private GameObject textoNuevo;
	public Text error;
    public float xPosicion=50;
    public float yPosicion=130;

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
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");
		string token = PlayerPrefs.GetString("token");

		headers.Add("token", token);

		byte[] pData = null;

		WWW www = new WWW("http://35.243.154.34:8090/api/v1/usuario/5bf59a9e5cd5fc001855bbc3/carta", pData, headers);

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
				GameObject nuevoSprite = (GameObject)Instantiate(spritePrefab);
				nuevoSprite.transform.SetParent(miPanel);
                nuevoSprite.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + carta.ToString());
                nuevoSprite.transform.localPosition = new Vector2(xPosicion, yPosicion);
                xPosicion = xPosicion + 110;
				miNumero++;
			}
		}
	}

	public void volverAlMenuPrincipal()
	{
		SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
	}

}
