using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaPegajosa : Estructura {
    public float tiempoParalizar;
	private bool shouldDestroy;
	private float timeToDestroy;
	private bool isEffectUsed;
    private AudioSource sonidoStun;
	// Use this for initialization
	void Start () {
		shouldDestroy = false;
		isEffectUsed = false;
        sonidoStun = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isEffectUsed && other.transform.tag == "Sicario")
        {
			isEffectUsed = true;
			Sicario enemigo = other.gameObject.GetComponent<Sicario>();
            enemigo.Paralizar(tiempoParalizar);
			shouldDestroy = true;
			timeToDestroy = Time.time + tiempoParalizar -0.9f;
            sonidoStun.Play();
        }
    }

	private void Update()
	{
		if (HasToExplode())
		{
			Debug.Log("Tiene que explotar");
			shouldDestroy = false;
			this.GetComponent<Animator>().SetTrigger("Destruir");
		}
	}

	private bool HasToExplode()
	{
		return shouldDestroy && Time.time >= timeToDestroy;
	}

    public void SetTiempoParalizar(float tiempo)
    {
        tiempoParalizar = tiempo;
    }
    public float GetTiempo()
    {
        return tiempoParalizar;
    }
}
