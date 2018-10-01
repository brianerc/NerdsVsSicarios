using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JugadorDeFootball : Arbol
{
    public GameObject jugadorDeFootballBase;

    // Use this for initialization
    protected override void Inicializar()
    {
        arbol = new Hoja[5][];
        nombre = "Jugador de Football";
        descripcion = "";
        for (int i = 0; i < arbol.Length; i++)
        {
            if (i == 0)
            {
                arbol[i] = new Hoja[1];
            }
            else
            {
                arbol[i] = new Hoja[0];
            }
        }
        InsertarHoja(new HojaJugadorDeFootballBase(jugadorDeFootballBase), 0);
        MostrarLanzadores();

    }
    protected override GameObject CargarLanzador(int i, int j)
    {
       return Resources.Load("Prefabs/Sicarios/" + arbol[i][j].GetNombre(), typeof(GameObject)) as GameObject;
    }

}