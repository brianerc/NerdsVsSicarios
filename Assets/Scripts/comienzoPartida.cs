using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComienzoPartida : MonoBehaviour {
    public GameObject jugador;
    public GameObject jugador2;
    public Grid matriz;
    public Arbol nerd;
    public float separacionLanzadores;
	// Use this for initialization
	void Start () {
        Instantiate(jugador);
        Instantiate(matriz);
        Instantiate(jugador2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
