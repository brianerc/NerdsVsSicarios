using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comienzoPartida : MonoBehaviour {
    public GameObject primeraCarta;
    public Grid matriz;
    public IArbol nerd;
	// Use this for initialization
	void Start () {
        Instantiate(primeraCarta);
        Instantiate(matriz);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
