using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeeabooLord : Arbol {
    public GameObject catapulta;
    public GameObject dakimakura;
    public GameObject mochilaPegajosa;
    // Use this for initialization
    protected override void Inicializar () {
        vidaBase = 10;
        danoBase = 2;
        tiempo = 1;
        tiempoBase = 1;
        arbol = new Hoja[5][];
        nombre = "Weeaboo Lord";
        descripcion = "";
        for (int i = 0; i < arbol.Length; i++)
        {
            if (i == 0)
            {
                arbol[i] = new Hoja[6];
            } else
            {
                arbol[i] = new Hoja[0];
            }
        }
       InsertarHoja(new HojaCatapulta(catapulta), 0);
        InsertarHoja(new HojaDakimakura(dakimakura), 0);
        InsertarHoja(new HojaMochilaPegajosa(mochilaPegajosa), 0);
        MostrarLanzadores();
    }

    protected override GameObject CargarLanzador(int i, int j)
    {
        return arbol[i][j].GetObjeto();
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
}