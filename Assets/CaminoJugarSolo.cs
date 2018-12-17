using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Servidor;
using Assets.Servidor.ServidorDTO;
using UnityEngine.UI;
using System;

public class CaminoJugarSolo : MonoBehaviour
{
    private int nivelJugador;
    private int nivelElegido;
    public Text error;
    bool posicionElegida = false;
    private int premio;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CargarNivelActual());
        nivelElegido = nivelJugador;
        MostrarInformacion();
        GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("N" + nivelJugador).transform.position;
    }

    private void CalcularPremio()
    {
        premio = nivelElegido * 3 / 2;
    }
    private void MostrarInformacion()
    {
        CalcularPremio();
        GameObject.FindGameObjectWithTag("MostrarInformacion").GetComponent<Text>().text = "Reward: " + premio;
        GameObject.FindGameObjectWithTag("Zona").GetComponent<Text>().text = "Zone: " + premio;
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
        }
    }

    // Update is called once per frame
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

                }
                if(int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador && int.Parse(hit.collider.name) !=nivelElegido)
                {
                    posicionElegida = false;
                    MostrarInformacion();
                }
                else if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador && posicionElegida)
                {
                    //JUGAR
                }
                else if (int.Parse(hit.collider.name) > 0 && int.Parse(hit.collider.name) < nivelJugador)
                {
                    GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("N" + nivelJugador).transform.position;
                    posicionElegida = true;
                }
            }
        }
    }
}
