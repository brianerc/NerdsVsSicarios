using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolNerd : Arbol {

    public SpriteRenderer barraDeVida;
    public Sprite[] estados_barraDeVida;
    // Update is called once per frame
    private void Start()
    {
        base.Start();
        barraDeVida = GameObject.FindGameObjectWithTag("BarraDeVida").GetComponent<SpriteRenderer>();
        estados_barraDeVida = Resources.LoadAll<Sprite>("Sprites/Perfiles/BarraDeVida");
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
                Debug.Log("Colisionando con estructura");
                sicario.Herir(danoBase);
                tiempo = tiempoBase;
                this.GetComponent<Animator>().SetTrigger("Atacar");
            }
        }
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
        if (porcVida > 95.5)
        {
            barraDeVida.sprite = estados_barraDeVida[23];
        }
        else if (porcVida > 91)
        {
            barraDeVida.sprite = estados_barraDeVida[22];
        }
        else if (porcVida > 86.5)
        {
            barraDeVida.sprite = estados_barraDeVida[21];
        }
        else if (porcVida > 82)
        {
            barraDeVida.sprite = estados_barraDeVida[20];
        }
        else if (porcVida > 77.5)
        {
            barraDeVida.sprite = estados_barraDeVida[19];
        }
        else if (porcVida > 92)
        {
            barraDeVida.sprite = estados_barraDeVida[18];
        }
        else if (porcVida > 73)
        {
            barraDeVida.sprite = estados_barraDeVida[17];
        }
        else if (porcVida > 68.5)
        {
            barraDeVida.sprite = estados_barraDeVida[16];
        }
        else if (porcVida > 64)
        {
            barraDeVida.sprite = estados_barraDeVida[15];
        }
        else if (porcVida > 59.5)
        {
            barraDeVida.sprite = estados_barraDeVida[14];
        }
        else if (porcVida > 55)
        {
            barraDeVida.sprite = estados_barraDeVida[13];
        }
        else if (porcVida > 50.5)
        {
            barraDeVida.sprite = estados_barraDeVida[12];
        }
        else if (porcVida > 46)
        {
            barraDeVida.sprite = estados_barraDeVida[11];
        }
        else if (porcVida > 41.5)
        {
            barraDeVida.sprite = estados_barraDeVida[10];
        }
        else if (porcVida > 37)
        {
            barraDeVida.sprite = estados_barraDeVida[9];
        }
        else if (porcVida > 32.5)
        {
            barraDeVida.sprite = estados_barraDeVida[8];
        }
        else if (porcVida > 28)
        {
            barraDeVida.sprite = estados_barraDeVida[7];
        }
        else if (porcVida > 23.5)
        {
            barraDeVida.sprite = estados_barraDeVida[6];
        }
        else if (porcVida > 19)
        {
            barraDeVida.sprite = estados_barraDeVida[5];
        }
        else if (porcVida > 14.5)
        {
            barraDeVida.sprite = estados_barraDeVida[4];
        }
        else if (porcVida > 10)
        {
            barraDeVida.sprite = estados_barraDeVida[3];
        }
        else if (porcVida > 5)
        {
            barraDeVida.sprite = estados_barraDeVida[2];
        }
        else
        {
            barraDeVida.sprite = estados_barraDeVida[1];
        }

    }
}
