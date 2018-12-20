using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaPegajosa : Estructura {

	public float tiempoParalizar;
	private bool debeDestruirse;
	private float tiempoParaDestruirse;
	private bool fueEfectoUsado; 
    private AudioSource sonidoStun;

	void Start () {
		debeDestruirse = false;
		fueEfectoUsado = false;
        sonidoStun = GetComponent<AudioSource>();
        tiempoParalizar = danoBase;
	}
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!fueEfectoUsado && other.transform.tag == "Sicario")
        {
			fueEfectoUsado = true;
			Sicario enemigo = other.gameObject.GetComponent<Sicario>();
            enemigo.Paralizar(tiempoParalizar);
			debeDestruirse = true;
			tiempoParaDestruirse = Time.time + tiempoParalizar -0.9f;
            sonidoStun.Play();
        }
    }

	private void Update()
	{
		if (TieneQueExplotar())
		{
			debeDestruirse = false;
			this.GetComponent<Animator>().SetTrigger("Destruir");
		}
	}

	private bool TieneQueExplotar()
	{
		return debeDestruirse && Time.time >= tiempoParaDestruirse;
	}

    public void SetearTiempoParalizar(float tiempo)
    {
        tiempoParalizar = tiempo;
    }

    public float GetTiempo()
    {
        return tiempoParalizar;
    }
}
