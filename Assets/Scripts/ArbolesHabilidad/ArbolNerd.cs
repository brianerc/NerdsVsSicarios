using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolNerd : Arbol {

    public SpriteRenderer barraDeVida;
    public Sprite[] estados_barraDeVida;
    protected AudioSource sonidoDaño;
    // Update is called once per frame
    private void Start()
    {
        base.Start();
        sonidoDaño = GetComponent<AudioSource>();
        barraDeVida = GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<SpriteRenderer>();
        estados_barraDeVida = Resources.LoadAll<Sprite>("Sprites/Partida/HUD/BarraDeVida");
    }
    override public void Update () {
        CalcularTiempoEnergia();
        ActualizarVida();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Sicario")
        {
            Sicario sicario = collision.gameObject.GetComponent<Sicario>();
            if (tiempo <= 0)
            {
                sicario.Herir(danoBase);
                tiempo = tiempoBase;
                this.GetComponent<Animator>().SetTrigger("Atacar");
            }
        }
    }
    public override void Herir(float danoBase)
    {
        base.Herir(danoBase);
        sonidoDaño.Play();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Sicario")
        {
            tiempo = tiempo - Time.deltaTime;
            if (tiempo <= 0)
            {
                Sicario sicario = collision.gameObject.GetComponent<Sicario>();
                sicario.Herir(danoBase);
                tiempo = tiempoBase;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        tiempo = tiempoBase;

    }
    void ActualizarVida()
    {
        float porcVida = (vidaBase * 100) / vidaInicial;
        if (porcVida > 89)
        {
            barraDeVida.sprite = estados_barraDeVida[0];
        }
        else if (porcVida > 77)
        {
            barraDeVida.sprite = estados_barraDeVida[1];
        }
        else if (porcVida > 66)
        {
            barraDeVida.sprite = estados_barraDeVida[2];
        }
        else if (porcVida > 55)
        {
            barraDeVida.sprite = estados_barraDeVida[3];
        }
        else if (porcVida > 44)
        {
            barraDeVida.sprite = estados_barraDeVida[4];
        }
        else if (porcVida > 32)
        {
            barraDeVida.sprite = estados_barraDeVida[5];
        }
        else if (porcVida > 21)
        {
            barraDeVida.sprite = estados_barraDeVida[6];
        }
        else if (porcVida > 10)
        {
            barraDeVida.sprite = estados_barraDeVida[7];
        }
        else
        {
            barraDeVida.sprite = estados_barraDeVida[8];
        }
    }
}
