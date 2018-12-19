using Assets.Scripts.ObjetosTablero.Proyectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Especificacion del objeto del tablero para todos los game objects correspondientes a los sicarios. 
/// Esta clase sigue estando sobre la jerarquia de sicarios. Los sicarios especificos especifican esta clase
/// con sus habilidades particulares correspondientes
/// </summary>
public class Sicario : ObjetoTablero {

    public float tiempoParalizado;
    public Vector3 velocidad;
    public Vector3 velocidadDetenida = new Vector3(0, 0, 0);
    public bool atacando=false;
    private bool colisiona = false;
    protected AudioSource[] sonidos;
    protected AudioSource sonidoCorrer;
    protected AudioSource sonidoAtacar;
    protected AudioSource sonidoHerido;
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

        if (collision.transform.tag == "Estructura" || collision.transform.tag == "Nerd")
		{
            this.GetComponent<Animator>().SetTrigger("Atacar");
            colisiona = true;
            sonidoCorrer.Stop();
			if (objetivos == null) {
				objetivos = new List<GameObject>();
			}
            objetivos.Add(collision.gameObject);
        }
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        objetivos = null;
		this.GetComponent<Animator>().SetTrigger("Detener");
	}
    public void SonidoAtacar()
    {
        sonidoAtacar.Play();
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


	/// <summary>
	/// Setea la cantidad de daño del sicario
	/// </summary>
	/// <param name="daño"></param>
    public void SetDaño(float daño) {
        danoBase = daño;
    }

    public override void Herir(float daño)
    {
        base.Herir(daño);
        sonidoHerido.Play();
    }

    public void SetVelocidad(float velocidadX)
    {
        velocidad= new Vector3(velocidadX, 0, 0);
    }

	/// <summary>
	/// Funcion correspondiente a setear la resictencia ante la paralizacion de objetos 
	/// que paralizan como la mochila pegajoza
	/// </summary>
	/// <param name="resistencia"></param>
    public void SetResistenciaParalizacion(float resistencia)
    {
        tiempoParalizado = tiempoParalizado * resistencia;
    }
}
