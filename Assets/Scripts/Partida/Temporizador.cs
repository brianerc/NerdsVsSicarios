using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Temporizador : MonoBehaviour {
    private int minutos;
    private float segundos;
    // Use this for initialization
    void Start () {
        minutos = 3;
        segundos = 00;
        this.GetComponent<Text>().text = minutos + ":" + segundos;

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
            SceneManager.LoadScene("Nerd_Victoria", LoadSceneMode.Single);
        }
        if(minutos>=0) GetComponent<Text>().text = minutos + ":" + Mathf.RoundToInt(segundos);
        
    }
}
