using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Servidor;
using Assets.Servidor.ServidorDTO;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CaminoJugarSolo : MonoBehaviour
{
    private int nivelJugador;
    private int nivelElegido;
    public Text error;
    bool posicionElegida = false;
    private int premio;
    private string zona;
    private string nombreEscena;
    public GameObject transicion;
    private GameObject avatar;
    // Start is called before the first frame update
    private Vector3[] posiciones;
    private int posicionDelAvatar;
    private float velocidadAvatar = 0.2f;
    private int destino;
    private Vector3 posicionObjetivo;
    bool llegoDestino;
    void Start()
    {
        llegoDestino = true;
        posiciones = new Vector3[11];
        for (int i = 1; i < 11; i++)
        {
            posiciones[i] = GameObject.FindGameObjectWithTag("N" + i).transform.position;
        }
        avatar = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(CargarNivelActual());

    }
    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    private void CalcularPremio()
    {
        premio = nivelElegido * 5 / 2;
    }
    private void MostrarInformacion()
    {
        CalcularPremio();
        GameObject.FindGameObjectWithTag("MostrarInformacion").GetComponent<Text>().text = "Reward: " + premio;
        if(nivelElegido>0 && nivelElegido<3)
        {
            zona = "Arcade";
        } else if(nivelElegido>2 && nivelElegido<7)
        {
            zona = "Backstreet";
        } else if (nivelElegido >6 && nivelElegido<10)
        {
            zona = "Park";
        } else
        {
            zona = "Boss Level";
        }
        GameObject.FindGameObjectWithTag("Zona").GetComponent<Text>().text = "Zone: " + zona;

    }

    private IEnumerator CargarNivelActual()
    {
        WWW www = Acciones.ObtenerInformacionUsuario();
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            error.text = www.error;
            error.color = Color.red;
            if (error.text.Equals("400 Bad Request"))
            {
                error.text = "No se pudo obtener informacion del usuario";
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
            Usuario resultObj = JsonUtility.FromJson<Usuario>(www.text);
            nivelJugador=resultObj.nivel;
            nivelElegido = nivelJugador;
            posicionDelAvatar = nivelElegido;
            MostrarInformacion();
            avatar.transform.position = posiciones[nivelJugador];
            destino = nivelJugador;
            posicionObjetivo = posiciones[nivelJugador];
            for (int i = 1; i < 11; i++)
            {
                if(nivelJugador<i)
                {
                    GameObject imagen = GameObject.FindGameObjectWithTag("N" + i);
                    imagen.tag = "Bloqueado";
                    imagen.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CaminoSinglePlayer/casilla_bloqueada");
                }
            }
            MostrarInformacion();
        }
    }

    // Update is called once per frame
    private void Jugar()
    {
        ComenzarPartidaSolo.cantidadExp = premio;
        ComenzarPartidaSolo.zona = zona;
        ComenzarPartidaSolo.nivel = nivelElegido;
        ComenzarPartidaSolo.nivelJugador = nivelJugador;
        FinalPartida.cantidadExp = premio;
        nombreEscena = "SeleccionNerd";
       LoadScene();
    }
    void Update()
    {
        MoverSiguientePosicion();
        MoverADestino();
        if (avatar.transform.position == posiciones[destino])
        {
            llegoDestino = true;
        }
        else
        {
            llegoDestino = false;
        }
        RaycastHit2D hit;
        if (Input.touchCount < 1)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        Vector2 test = Camera.main.ScreenToWorldPoint(touch.position);
        hit = Physics2D.Raycast(test, (touch.position));
        if (touch.phase == TouchPhase.Began)
        {
            if (hit.collider != null)
            {
                if(hit.collider.tag=="Finish")
                {
                    nombreEscena = "MenuPrincipal";
                    LoadScene();
                } else if(hit.collider.tag=="Jugar")
                {
                    Jugar();
                }
                try {
                    if (hit.collider.tag.Contains("N"))
                    {
                        if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador + 1 && int.Parse(hit.collider.name) != nivelElegido)
                        {
                            nivelElegido = int.Parse(hit.collider.name);
                            MostrarInformacion();

                        }
                        else if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador + 1 )
                        {
                            Jugar();
                        }
                
                    }
                } catch
                {

                }
            }
        }
    }

    private void MoverSiguientePosicion()
    {
        if (llegoDestino)
        {
            if (nivelElegido > posicionDelAvatar)
            {
                destino = posicionDelAvatar + 1;
            }
            else if (nivelElegido < posicionDelAvatar)
            {
                destino = posicionDelAvatar - 1;
            }
            avatar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CaminoSinglePlayer/nerd avatar");
        }
    }


    private void MoverADestino()
    {
        avatar.transform.position = Vector2.MoveTowards(avatar.transform.position, posiciones[destino],velocidadAvatar);
        if(avatar.transform.position.y<posiciones[destino].y)
        {
            avatar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CaminoSinglePlayer/nerd avatar espalda");
        }
        else if(avatar.transform.position.y>posiciones[destino].x)
        {
            avatar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CaminoSinglePlayer/nerd avatar");
        }
        if (avatar.transform.position.x < posiciones[destino].x)
        {
            avatar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CaminoSinglePlayer/nerd avatar derecha");
        }
        else if (avatar.transform.position.x > posiciones[destino].x)
        {
            avatar.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/CaminoSinglePlayer/nerd avatar izquierda");
        }
        posicionDelAvatar = destino;
    }

}
