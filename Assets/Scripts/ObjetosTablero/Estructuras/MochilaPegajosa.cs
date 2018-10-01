using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaPegajosa : Estructura {
    private float tiempoParalizar;
	// Use this for initialization
	void Start () {
        tiempoParalizar=2;
        vidaBase = 1;
	}
	
	// Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sicario")
        {
            Sicario enemigo = other.gameObject.GetComponent<Sicario>();
            enemigo.Paralizar(tiempoParalizar);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Destruir();
    }
}
