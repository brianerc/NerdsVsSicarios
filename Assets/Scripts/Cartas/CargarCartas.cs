using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.ServidorDTO;
using Assets.Servidor;

public class CargarCartas : MonoBehaviour
{

	public RectTransform miScrollPanel;
    public string cartaElegida;
	public GameObject imagenPrefab;
	private int miNumero = 0;
	public Text error;
    public float xPosicion =    50;
    public float yPosicion =    50;
    public RectTransform panelMejorar;
    private GameObject flechaDerecha;
    private GameObject flechaIzquierda;
    private GameObject cartaAMejorar;
    private GameObject cartaMejorada;
    private float tiempoTouch;
    private float tiempoMaximoTouch = 0.7f;
    // Use this for initialization
    void Start()
	{
		error.text = "";
		//nextMessage = Time.time + 1f;
		StartCoroutine(ObtenerCartas());
        cartaAMejorar = (GameObject)Instantiate(imagenPrefab);
        cartaAMejorar.transform.SetParent(panelMejorar);
        cartaAMejorar.transform.localPosition = new Vector2(xPosicion, yPosicion);
        cartaMejorada = (GameObject)Instantiate(imagenPrefab);
        cartaMejorada.transform.SetParent(panelMejorar);
        cartaMejorada.transform.localPosition = new Vector2(xPosicion+210, yPosicion);
        panelMejorar.gameObject.SetActive(false);
        flechaIzquierda = GameObject.FindGameObjectWithTag("FlechaIzquierda");
        flechaDerecha = GameObject.FindGameObjectWithTag("FlechaDerecha");
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
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider && hit.collider.tag.Contains("Lanzador"))
            {
                tiempoTouch = 0;
            }
            else if (hit.collider && hit.collider.tag == "MostrarCartas")
            {
                MostrarElegirCarta();
            }
            else if (hit.collider && hit.collider.tag == "MejorarCarta")
            {
                if (cartaElegida != null)
                {
                    Debug.Log("Mal");
                    MostrarMejorarCarta(cartaElegida);
                }
            }
        }
        if (touch.phase == TouchPhase.Moved)
        {
            tiempoTouch = 0;
        }
        if (touch.phase == TouchPhase.Stationary)
        {
            if (hit.collider && hit.collider.tag.Contains("Lanzador") && tiempoTouch< tiempoMaximoTouch)
            {
                tiempoTouch=tiempoTouch +Time.deltaTime;
            } else if(hit.collider&&hit.collider.tag.Contains("Lanzador"))
            {
                MostrarMejorarCarta(GameObject.FindGameObjectWithTag(hit.collider.tag).GetComponent<Image>().name);
            }
        }
  
        if (touch.phase == TouchPhase.Ended)
        {
            if (hit.collider && hit.collider.tag.Contains("Lanzador" ) && tiempoTouch>tiempoMaximoTouch)
            {
                MostrarMejorarCarta(GameObject.FindGameObjectWithTag(hit.collider.tag).GetComponent<Image>().name);
            }
            else if(hit.collider && hit.collider.tag.Contains("Lanzador"))
            {
                cartaElegida = GameObject.FindGameObjectWithTag(hit.collider.tag).GetComponent<Image>().name;
            } 
        }
    }
    private void MostrarMejorarCarta(string nombre) {
        miScrollPanel.gameObject.SetActive(false);
        flechaDerecha.SetActive(false);
        flechaIzquierda.SetActive(false);
        panelMejorar.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("MostrarCartas").GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Sprites/MenuCartas/menu cartas cerrado");
        cartaAMejorar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + nombre);
        cartaAMejorar.name = nombre;
        cartaMejorada.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + nombre);
        cartaMejorada.name = nombre;
    }
    private void MostrarElegirCarta()
    {
        
        miScrollPanel.gameObject.SetActive(true);
        flechaDerecha.SetActive(true);
        flechaIzquierda.SetActive(true);
        panelMejorar.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("MostrarCartas").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/menu cartas abierto");

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
				error.text = "No se pudo obtener cartas";
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
                nuevoSprite.transform.SetParent(miScrollPanel);
                nuevoSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/Lanzadores/" + carta.ToString());
                nuevoSprite.name = carta.ToString();
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
