using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Servidor;

public class Temporizador : MonoBehaviour {
    private int minutos;
    private float segundos;
    public GameObject transicion;
    private string nombreEscena;
    protected bool termino = false;
    // Use this for initialization
    void Start () {
        minutos = 10;
        segundos = 30;
        this.GetComponent<Text>().text = minutos + ":" + segundos;

    }
    private void LoadScene()
    {
        Transicion.nombreEscena = nombreEscena;
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!termino)
        {
            segundos = segundos - Time.deltaTime;

            if (segundos <= 0)
            {
                minutos--;
                segundos = 59;
            }
            if (minutos < 0)
            {
                nombreEscena = "Nerd_Victoria";
                if (ComenzarPartidaSolo.nivel > 0 && ComenzarPartidaSolo.nivel == ComenzarPartidaSolo.nivelJugador && ComenzarPartidaSolo.nivel!=10)
                {
                    StartCoroutine(SubirDeNivel());
                }
                termino = true;
                LoadScene();
            }
            if (minutos >= 0) GetComponent<Text>().text = minutos + ":" + Mathf.RoundToInt(segundos);

        }

    }
    public IEnumerator SubirDeNivel()
    {
        WWW www = Acciones.SubirDeNivel();
        yield return www;
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            Debug.Log("EN ERROR");
        }
        else
        {
            Debug.Log("EXITO: ");
            Debug.Log(www.text);

        }
    }
}
