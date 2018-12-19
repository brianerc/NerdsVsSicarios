using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Temporizador : MonoBehaviour {
    private int minutos;
    private float segundos;
    public GameObject transicion;
    private string nombreEscena;
    // Use this for initialization
    void Start () {
        minutos = 3;
        segundos = 0;
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
        segundos = segundos - Time.deltaTime;

        if (segundos <= 0)
        {
            minutos--;
            segundos = 59;
        }
        if (minutos < 0)
        {
            nombreEscena = "Nerd_Victoria";
            LoadScene();
        }
        if(minutos>=0) GetComponent<Text>().text = minutos + ":" + Mathf.RoundToInt(segundos);
        
    }
}
