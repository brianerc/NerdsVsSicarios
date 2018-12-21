using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.ServidorDTO;
using Assets.Servidor;
using System;

public class CargarCartas : MonoBehaviour
{
    public Dictionary<string,string> idCarta;
    public Dictionary<string, int> puntosRequeridos;
    public string cartaElegida;
	public GameObject imagenPrefab;
	private int miNumero = 0;
	public Text error;
    public float xPosicion =    -300;
    public float yPosicion =    0;
    public RectTransform panelMejorar;
    public RectTransform panelElegirJugador;
    public RectTransform panelElegirCarta;
    private GameObject cartaAMejorar;
    private GameObject cartaMejorada;
    bool puedoElegir;
    int exp;
    public GameObject mostrarCosto;
    public GameObject transicion;
    private string nombreEscena;
    private bool cargandoCartas = false;
	public AudioSource opcionMenu;
    string mazoElegido = "";
    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    // Use this for initialization
    void Start()
	{
        panelElegirCarta.gameObject.SetActive(false);
        puedoElegir = false;
        idCarta = new Dictionary<string, string>();
        puntosRequeridos = new Dictionary<string, int>();
		error.text = "";
        cartaElegida = "";
		//nextMessage = Time.time + 1f;
        cartaAMejorar = (GameObject)Instantiate(imagenPrefab);
        cartaAMejorar.transform.SetParent(panelMejorar);
        cartaAMejorar.transform.localPosition = new Vector2(xPosicion, yPosicion);
        cartaMejorada = (GameObject)Instantiate(imagenPrefab);
        cartaMejorada.transform.SetParent(panelMejorar);
        cartaMejorada.transform.localPosition = new Vector2(xPosicion+210, yPosicion);
        panelMejorar.gameObject.SetActive(false);
        CargarExperiencia();
        GameObject.FindGameObjectWithTag("MejorarCarta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/level_up_ByN");
        
    }
    // Update is called once per frame
    void Update()
    { 
        if(cargandoCartas)
        {
            StartCoroutine(ObtenerCartas(mazoElegido));
        }
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
                cartaElegida = GameObject.FindGameObjectWithTag(hit.collider.tag).GetComponent<Image>().name;
                MostrarMejorarCarta(GameObject.FindGameObjectWithTag(hit.collider.tag).GetComponent<Image>().name);
            }
            else if (hit.collider && (hit.collider.name == "Weeaboo" || hit.collider.name == "ITGuy" || hit.collider.name == "Emo"))
            {
				opcionMenu.Play();
                mazoElegido = hit.collider.name;
                ActualizarDatos();
                cargandoCartas = true;
                ObtenerCartas(hit.collider.name);
            } else if(hit.collider && hit.collider.tag=="MostrarCartas")
            {
                DestruirCartas();
                opcionMenu.Play();
                MostrarElegirPersonaje();
            }
            else if (hit.collider &&(hit.collider.tag == "MejorarCarta" || hit.collider.tag=="MostrarCostoExp"))
            {
				opcionMenu.Play();
				if (cartaElegida != null && puedoElegir)
                {
                    StartCoroutine(MejorarCarta());
                }
            }
        }
 
    }

    private IEnumerator MejorarCarta()
    {
        WWW www = Acciones.SubirDeNivelCarta(idCarta[cartaElegida]);
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            error.text = www.error;
            error.color = Color.red;
            if (error.text.Equals("400 Bad Request"))
            {
                error.text = "No se pudo mejorar la carta";
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
			MostrarElegirPersonaje();
            ActualizarDatos();
        }
    }

    private void MostrarMejorarCarta(string nombre)
    {
        GameObject.FindGameObjectWithTag("MostrarCartas").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/menu cartas abierto");
        panelElegirJugador.gameObject.SetActive(false);
        panelMejorar.gameObject.SetActive(true);
        panelElegirCarta.gameObject.SetActive(false);
        cartaAMejorar.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/MostrarCartas/" + nombre);
        cartaAMejorar.name = nombre;
        int nivel = int.Parse(nombre.Substring(nombre.Length - 1)) + 1;
        int nivelInicial = nivel-1;
        string nombreBase = nombre.Substring(0, nombre.Length - 1);
        nombre = nombreBase + nivel;
        if (nivel < 5) {
            cartaMejorada.SetActive(true);
            cartaMejorada.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/MostrarCartas/" + nombre);
            cartaMejorada.name = nombre;
            cartaElegida = nombre.Substring(0,nombre.Length - 3);
            mostrarCosto.GetComponent<Text>().text = puntosRequeridos[cartaElegida] * nivelInicial + "EXP";
            if (exp >  puntosRequeridos[cartaElegida])
            {
                puedoElegir = true;
                GameObject.FindGameObjectWithTag("MejorarCarta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/level up");
            }
            else
            {
                GameObject.FindGameObjectWithTag("MejorarCarta").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/level_up_ByN");
                puedoElegir = false;
            }
        } else
        {
            cartaMejorada.SetActive(false);

        }

    }
    private void MostrarElegirCarta()
    {
        mostrarCosto.GetComponent<Text>().text = "";

        mazoElegido = "";
        GameObject.FindGameObjectWithTag("MostrarCartas").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/menu cartas abierto");
        cartaElegida = "";
        panelElegirCarta.gameObject.SetActive(true);
        panelMejorar.gameObject.SetActive(false);
        panelElegirJugador.gameObject.SetActive(false);
    }
    private void MostrarElegirPersonaje()
    {
        mostrarCosto.GetComponent<Text>().text ="";

        cartaElegida = "";
        panelElegirCarta.gameObject.SetActive(true);
        DestruirCartas();
        panelElegirCarta.gameObject.SetActive(false);
        panelMejorar.gameObject.SetActive(false);
        panelElegirJugador.gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("MostrarCartas").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/menu cartas cerrado");

    }

    public void DestruirCartas()
    {
        foreach (GameObject carta in GameObject.FindObjectsOfType<GameObject>())
        {
            if(carta.transform.tag.Contains("Lanzador"))
            {
                Destroy(carta);                
            }
        }
        idCarta.Clear();
        puntosRequeridos.Clear();
    }
    public void ActualizarDatos()
    {
        StartCoroutine(ManejadorUsuario.CargarUsuario());
        StartCoroutine(ManejadorUsuario.CargarCartas());
        cargandoCartas = true;
    }
    public IEnumerator ObtenerCartas(string mazo)
	{
        //Matcheo con bd.
        if (mazo == "Emo")
        {
            mazo = "nerd-punk-girl";
        } else if(mazo=="ITGuy")
        {
            mazo = "nerd-it-guy";
        } else
        {
            mazo = "nerd-weabooLord";
        }
        if(ManejadorUsuario.cargoCartas && ManejadorUsuario.cargoUsuario)
        {
            cargandoCartas = false;
            panelElegirJugador.gameObject.SetActive(false);
            panelElegirCarta.gameObject.SetActive(true);
            WWW www = Acciones.CargarCartas();
            GameObject.FindGameObjectWithTag("MostrarCartas").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/MenuCartas/menu cartas abierto");
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
                ManejadorUsuario.cartasUsuario = resultObj.cartas;
                for (int i = 0; i < resultObj.cartas.Count; i++)
                {
                        
                        Assets.Scripts.ServidorDTO.Carta carta = resultObj.cartas[i];
                    if (carta.tipo == mazo)
                        {
                        GameObject nuevoSprite = (GameObject)Instantiate(imagenPrefab);
                        nuevoSprite.transform.SetParent(panelElegirCarta);
                        nuevoSprite.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Partida/MostrarCartas/" + carta.ToString());
                        nuevoSprite.name = carta.ToString();
                        nuevoSprite.transform.tag = "Lanzador" + carta.nombre_completo;
                        xPosicion = xPosicion + 310;
                        nuevoSprite.transform.localPosition = new Vector2(xPosicion, yPosicion);

                        miNumero++;
                        idCarta.Add(carta.nombre_completo, carta._id);
                        puntosRequeridos.Add(carta.nombre_completo, carta.costo_para_desbloquear);
                    }
                }
                CargarExperiencia();
            }
        }

    }

	public void VolverAlMenuPrincipal()
	{
		opcionMenu.Play();
		nombreEscena = "MenuPrincipal";
        LoadScene();
    }
    public void CargarExperiencia()
    {
        exp = ManejadorUsuario.ObtenerUsuario().puntos;
        GameObject.FindGameObjectWithTag("MostrarExp").GetComponent<Text>().text = "You have " + exp + "EXP";
    }

}
