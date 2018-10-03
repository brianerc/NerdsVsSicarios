using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sicario : ObjetoTablero {

    public float tiempoBase;
    public float tiempo;
    public float danoBase;
    public float tiempoParalizado;
    public Vector3 velocidad;
    public Vector3 velocidadDetenida = new Vector3(0, 0, 0);
    public bool atacando=false;
    public virtual void Paralizar(float tiempoParalizar)
    {
        tiempoParalizado = tiempoParalizar;
    }
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = velocidad;
    }
    private void OnCollisionEnter(Collision collision)
    {
		if (collision.transform.tag == "Estructura")
		{
			Estructura estructura = collision.gameObject.GetComponent<Estructura>();
			if (tiempo <= 0)
			{
				Debug.Log("Colisionando con estructura");
				estructura.Herir(danoBase);
				tiempo = tiempoBase;
				this.GetComponent<Animator>().SetTrigger("Atacar");
			}
		}
        else if(collision.transform.tag=="Nerd")
        {
            Debug.Log("Nerd choco");
        }
		else if (collision.transform.tag == "Proyectil_Nerd")
		{
			Debug.Log("PROYECTIL NERD");
		}

	}
    private void OnCollisionExit(Collision collision)
    {
        this.GetComponent<Animator>().SetTrigger("Detener");

    }
    private void FixedUpdate()
    {
        tiempo = tiempo - Time.deltaTime;
        if (tiempoParalizado > 0)
        {
            tiempoParalizado = tiempoParalizado - Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocidadDetenida;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocidad;
        }
    }
    public void SetTiempo(float unTiempo)
    {
        tiempoBase = unTiempo;
        tiempo = tiempoBase;
    }
    public void SetDaño(float daño) {
        danoBase = daño;
    }
    public void SetVelocidad(float velocidadX)
    {
        velocidad= new Vector3(velocidadX, 0, 0);
    }
    public void SetResistenciaParalizacion(float resistencia)
    {
        tiempoParalizado = tiempoParalizado * resistencia;
    }
    public void Morir()
    {
        Destruir();
    }
}
