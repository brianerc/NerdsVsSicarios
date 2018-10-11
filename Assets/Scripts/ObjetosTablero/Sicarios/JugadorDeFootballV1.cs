using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballV1 : Sicario
{

	void Start () {
        this.GetComponent<Rigidbody2D>().velocity = velocidad;
        sonidoCorrer = GetComponent<AudioSource>();

    }

}