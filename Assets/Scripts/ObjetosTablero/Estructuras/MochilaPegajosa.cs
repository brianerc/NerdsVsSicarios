using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochilaPegajosa : Estructura {
    public float tiempoParalizar;
	// Use this for initialization
	void Start () {
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
    public void SetTiempoParalizar(float tiempo)
    {
        tiempoParalizar = tiempo;
    }
    public float GetTiempo()
    {
        return tiempoParalizar;
    }
}
