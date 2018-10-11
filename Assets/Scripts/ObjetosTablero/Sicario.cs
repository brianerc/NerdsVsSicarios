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
    private bool colisiona = false;
    protected AudioSource sonidoCorrer;
    public virtual void Paralizar(float tiempoParalizar)
    {
        sonidoCorrer.Stop();
        tiempoParalizado = tiempoParalizar;
    }
    void Start()
    {
        sonidoCorrer = GetComponent<AudioSource>();
        this.GetComponent<Rigidbody>().velocity = velocidad;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        colisiona = true;
        sonidoCorrer.Stop();
        this.GetComponent<Animator>().SetTrigger("Atacar");
        if (collision.transform.tag == "Estructura")
		{
			Estructura estructura = collision.gameObject.GetComponent<Estructura>();
            if (tiempo <= 0)
			{
				Debug.Log("Colisionando con estructura");
				estructura.Herir(danoBase);
				tiempo = tiempoBase;
			}
		}
        else if(collision.transform.tag=="Nerd")
        {
            Arbol nerd = collision.gameObject.GetComponent<Arbol>();
            nerd.Herir(danoBase);
        }
		else if (collision.transform.tag == "Proyectil_Nerd")
		{
			Debug.Log("PROYECTIL NERD");
		}

	}
    private void OnCollisionStay2D(Collision2D collision)
    {
        tiempo = tiempo - Time.deltaTime;
        if (collision.transform.tag == "Estructura")
        {
            Estructura estructura = collision.gameObject.GetComponent<Estructura>();
            if (tiempo <= 0 && vidaBase>0)
            {
                Debug.Log("Colisionando con estructura");
                estructura.Herir(danoBase);
                tiempo = tiempoBase;
                this.GetComponent<Animator>().SetTrigger("Atacar");
            }
        }
        else if (collision.transform.tag == "Nerd")
        {
            if (tiempo <= 0 && vidaBase>0)
            {
            Arbol nerd = collision.gameObject.GetComponent<Arbol>();
            nerd.Herir(danoBase);
            tiempo = tiempoBase;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colisiona = false;
        this.GetComponent<Animator>().SetTrigger("Detener");
        tiempo = 1;
        sonidoCorrer.Play();
    }
    private void FixedUpdate()
    {
        if(vidaBase<=0)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocidadDetenida;
        }
        if (tiempoParalizado > 0)
        {
            tiempoParalizado = tiempoParalizado - Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = velocidadDetenida;
        }
        else
        {
            if (!sonidoCorrer.isPlaying && !colisiona)
            {
                sonidoCorrer.Play();
            }
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
