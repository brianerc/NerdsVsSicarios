using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComenzarPartidaSolo : Comenzar {
    public GameObject fondo;
    public GameObject jugador;
    public Grid matriz;
    public GameObject temporizador;
    public GameObject energiaNerd;
    // Use this for initialization
    void Start () {
        Instantiate(fondo);
        Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(temporizador);
        Instantiate(energiaNerd);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Nerd").GetComponent<Arbol>().GetVida() <= 0)
        {
            SceneManager.LoadScene("Nerd_Derrota");
        }
    }
}
