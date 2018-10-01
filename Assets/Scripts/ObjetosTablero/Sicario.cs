using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sicario : ObjetoTablero {

    protected float tiempo;
    protected float danoBase;
    protected float tiempoParalizado;
    protected Vector3 velocidad;
    protected Vector3 velocidadDetenida;
    public virtual void Paralizar(float tiempoParalizar)
    {
        tiempoParalizado = tiempoParalizar;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Estructura")
        {
            Estructura estructura = collision.gameObject.GetComponent<Estructura>();
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
        if (tiempoParalizado > 0)
        {
            tiempoParalizado = tiempoParalizado - Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody>().velocity = velocidadDetenida;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = velocidad;
        }
    }
    public void Morir()
    {
        Destruir();
    }
}
