using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkGirlV2 : Sicario {

    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = velocidad;
        sonidos = GetComponents<AudioSource>();
        sonidoCorrer = sonidos[0];
        sonidoAtacar = sonidos[1];
        sonidoHerido = sonidos[2];
    }
}
