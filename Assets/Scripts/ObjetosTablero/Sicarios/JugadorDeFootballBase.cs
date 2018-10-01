using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballBase : Sicario {
	// Use this for initialization
	void Start () {
        vidaBase = 10;
        tiempo = 1;
        danoBase = 5;
        tiempoParalizado = 0;
        velocidad = new Vector3(-5f, 0, 0);
        velocidadDetenida = new Vector3(0, 0, 0);
    }


}
