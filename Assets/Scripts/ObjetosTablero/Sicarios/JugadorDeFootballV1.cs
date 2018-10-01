using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballV1 : Sicario {

	void Start () {
        vidaBase = 8;
        tiempo = 1;
        danoBase = 5;
        tiempoParalizado = 0;
        velocidad = new Vector3(-9f, 0, 0);
        velocidadDetenida = new Vector3(0, 0, 0);
    }

}