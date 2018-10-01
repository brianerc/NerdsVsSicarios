using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballV2 : Sicario {

	// Use this for initialization
	void Start () {
        vidaBase = 14;
        tiempo = 1;
        danoBase = 8;
        tiempoParalizado = 0;
        velocidad = new Vector3(-3f, 0, 0);
        velocidadDetenida = new Vector3(0, 0, 0);
    }

}
