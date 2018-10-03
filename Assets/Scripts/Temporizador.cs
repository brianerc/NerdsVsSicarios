using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Temporizador : MonoBehaviour {
    private int minutos;
    private float segundos;
    // Use this for initialization
    void Start () {
        minutos = 2;
        segundos = 59;
        this.GetComponent<Text>().text = minutos + ":" + segundos;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Text>().text = minutos + ":" + Mathf.RoundToInt(segundos);
        segundos = segundos - Time.deltaTime;
        if (segundos <= 0)
        {
            minutos--;
            segundos = 59;
        }
        if(segundos==0 && minutos==0)
        {
            Application.LoadLevel("Victoria_Nerd");
        }
    }
}
