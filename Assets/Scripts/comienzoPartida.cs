using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComienzoPartida : MonoBehaviour {
    public GameObject jugador;
    public Grid matriz;
    public IArbol nerd;
    public float separacionLanzadores;
	// Use this for initialization
	void Start () {
        Instantiate(jugador);
        Instantiate(matriz);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
