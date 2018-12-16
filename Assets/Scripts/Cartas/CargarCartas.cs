using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.ServidorDTO;

public class CargarCartas : MonoBehaviour
{

	public RectTransform miPanel;
	public GameObject imagenPrefab;
	private int miNumero = 0;
	private GameObject textoNuevo;
	public Text error;
    public float xPosicion =    50;
    public float yPosicion =    50;
    private string tagSeleccionado;
    bool elegido;
    // Use this for initialization
    void Start()
	{
		error.text = "";
		//nextMessage = Time.time + 1f;
		StartCoroutine(ObtenerCartas());
        elegido = false;
	}
	// Update is called once per frame
	void Update()
	{
        if (Input.touchCount < 1)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position), Input.GetTouch(0).position);

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            if (hit.collider && tagSeleccionado != hit.collider.tag)
            {
                elegido = false;
            } 
        }
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider )
            {
                elegido = true;
                tagSeleccionado = hit.collider.tag;
            }
            else
            {
                elegido = false;
                tagSeleccionado = "";
            }
        }
        if (touch.phase == TouchPhase.Ended)
        {
            if (hit.collider && hit.collider.tag.Contains("Lanzador" ) && elegido)
            {
                miPanel.gameObject.SetActive(false);
            }
        }
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
				GameObject nuevoSprite = (GameObject)Instantiate(imagenPrefab);
                nuevoSprite.transform.SetParent(miPanel);
                nuevoSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + carta.ToString());
                nuevoSprite.transform.localPosition = new Vector2(xPosicion, yPosicion);
                nuevoSprite.transform.tag = "Lanzador" + carta.nombre_completo;
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
