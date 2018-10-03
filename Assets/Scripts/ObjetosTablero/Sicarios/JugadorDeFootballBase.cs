using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballBase : Sicario {
	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = velocidad;
    }


}
