using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaPegajosa : MonoBehaviour {
    private float tiempoParalizar;
    private float vidaBase;
	// Use this for initialization
	void Start () {
        tiempoParalizar=2;
        vidaBase = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(vidaBase<=0)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sicario")
        {
            JugadorDeFootballBase enemigo = other.gameObject.GetComponent<JugadorDeFootballBase>();
            enemigo.paralizar(tiempoParalizar);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(this.gameObject);
    }
    private void Herir(float dano)
    {
        vidaBase = vidaBase - dano;
    }
}
