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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CargarNivelActual());

    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadSceneAsync(nombreEscena);
    }
    private void CalcularPremio()
    {
        premio = nivelElegido * 3 / 2;
    }
    private void MostrarInformacion()
    {
        CalcularPremio();
        GameObject.FindGameObjectWithTag("MostrarInformacion").GetComponent<Text>().text = "Reward: " + premio;
        if(nivelElegido<0 && nivelElegido<3)
        {
            zona = "Arcade";
        } else if(nivelElegido>2 && nivelElegido<7)
        {
            zona = "Backstreet";
        } else if (nivelElegido >7 && nivelElegido<10)
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
            MostrarInformacion();
            GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("N" + nivelJugador).transform.position;
        }
    }

    // Update is called once per frame
    private void Jugar()
    {
        ComenzarPartidaSolo.cantidadExp = premio;
        ComenzarPartidaSolo.zona = zona;
        nombreEscena = "PartidaSolo";
        StartCoroutine(LoadScene());
    }
    void Update()
    {
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
                    StartCoroutine(LoadScene());
                } else if(hit.collider.tag=="Jugar")
                {
                    Jugar();
                }
                try {
                    if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador && int.Parse(hit.collider.name) != nivelElegido)
                    {
                        posicionElegida = false;
                        MostrarInformacion();
                    }
                    else if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador && posicionElegida)
                    {
                        Jugar();
                    }
                    else if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador)
                    {
                        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("N" + nivelJugador).transform.position;
                        posicionElegida = true;
                    }
                } catch
                {

                }
            }
        }
    }
}
