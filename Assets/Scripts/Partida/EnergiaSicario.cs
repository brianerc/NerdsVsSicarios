using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaSicario : Energia {

	// Use this for initialization
	void Start () {
        texto = this.GetComponent<Text>();
        jugador = GameObject.FindGameObjectWithTag("JugadorSicario").GetComponent<Mazo>();
    }

}
