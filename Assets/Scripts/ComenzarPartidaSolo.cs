﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Especificacion de la clase comenzar para la logica sobre una partida single player
/// </summary>
public class ComenzarPartidaSolo : Comenzar {
    public GameObject fondo;
    public GameObject jugador;
    public Grid matriz;
    public GameObject temporizador;
    public GameObject energiaNerd;
    public GameObject transicion;
    private string nombreEscena;

	void Start () {
        Instantiate(fondo);
        Instantiate(jugador);
        Instantiate(matriz);
        temporizador.GetComponent<Temporizador>().transicion = transicion;
        Instantiate(temporizador);
        Instantiate(energiaNerd);
    }
    IEnumerator LoadScene()
    {
        transicion.GetComponent<Animator>().SetTrigger("Cerrar");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
    }
    void Update () {
        if (GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().GetVida() <= 0)
        {
            nombreEscena = "Nerd_Derrota";
            StartCoroutine(LoadScene());
        }
    }
}
