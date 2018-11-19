using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente al jugador nerd "maestro". Este es el personaje princial de los nerds y en esta 
/// clase se mantiene la logica correspondiente a el
/// </summary>
public class WeeabooLord : ArbolNerd {
    public GameObject catapulta;
    public GameObject dakimakura;
    public GameObject mochilaPegajosa;

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
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        catapulta.GetComponent<ObjetoTablero>().nivel = 1;
        dakimakura.GetComponent<ObjetoTablero>().nivel = 1;
        mochilaPegajosa.GetComponent<ObjetoTablero>().nivel = 1;
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