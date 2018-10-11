using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballV2 : Sicario
{

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = velocidad;
        sonidoCorrer = GetComponent<AudioSource>();

    }

}
