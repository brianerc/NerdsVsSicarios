using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeeabooLord : ArbolNerd {
    public GameObject catapulta;
    public GameObject dakimakura;
    public GameObject mochilaPegajosa;
    // Use this for initialization
    protected override void Inicializar () {
        vidaBase = 50;
        danoBase = 5;
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
        energia = 100;
        InsertarHoja(new HojaCatapulta(catapulta), 0);
        InsertarHoja(new HojaDakimakura(dakimakura), 0);
        InsertarHoja(new HojaMochilaPegajosa(mochilaPegajosa), 0);
        MostrarLanzadores();
    }

    protected override GameObject CargarLanzador(int i, int j)
    {
        return arbol[i][j].GetObjeto();
    }

}