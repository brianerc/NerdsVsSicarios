using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
abstract public class Energia : MonoBehaviour {
    public Arbol jugador;
    protected Text texto;
    // Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        texto.text = jugador.GetEnergia().ToString();
	}
}
