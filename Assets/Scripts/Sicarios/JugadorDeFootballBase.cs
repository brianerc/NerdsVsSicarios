using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorDeFootballBase : MonoBehaviour {
    private float vida;
    private float tiempo;
    private float danoBase;
    private float tiempoParalizado;
    private Vector3 velocidad;
    private Vector3 velocidadDetenida;
	// Use this for initialization
	void Start () {
        vida = 10;
        tiempo = 1;
        danoBase = 5;
        tiempoParalizado = 0;
        velocidad = new Vector3(-5f, 0, 0);
        velocidadDetenida = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void Herir(float dano)
    {
        vida = vida - dano;
        if(vida<=0)
        {
            this.GetComponent<Animator>().SetTrigger("Muerte");
        }
    }

    internal void paralizar(float tiempoParalizar)
    {
        tiempoParalizado = tiempoParalizar;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Estructura")
        {
            Dakimakura estructura = collision.gameObject.GetComponent<Dakimakura>();
            if (tiempo <= 0)
            {
                estructura.Herir(danoBase);
                tiempo = 1;
            }
        }
    }
    private void FixedUpdate()
    {
        tiempo = tiempo - Time.deltaTime;
        if(tiempoParalizado>0)
        {
            tiempoParalizado = tiempoParalizado - Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody>().velocity = velocidadDetenida;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = velocidad;
        }
    }
    public void Matar()
    {
        Destroy(this.gameObject);
    }
}
