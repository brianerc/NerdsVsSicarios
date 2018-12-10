using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergiaNerd : Energia {

	// Use this for initialization
	void Start () {
        jugador = GameObject.FindGameObjectWithTag("Nerd").GetComponent<Mazo>();
        texto = this.GetComponent<Text>();
    }
}
