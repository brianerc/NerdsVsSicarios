using System.Collections;
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

	void Start () {
        Instantiate(fondo);
        Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(temporizador);
        Instantiate(energiaNerd);
    }
	
	void Update () {
        if (GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>().GetVida() <= 0)
        {
            SceneManager.LoadScene("Nerd_Derrota");
        }
    }
}
