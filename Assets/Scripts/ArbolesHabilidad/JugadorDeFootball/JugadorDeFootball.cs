using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JugadorDeFootball : Arbol
{
    public GameObject jugadorDeFootballBase;
    public GameObject jugadorDeFootballV1;
    public GameObject jugadorDeFootballV2;

    // Use this for initialization
    protected override void Inicializar()
    {
        posicionX = (-posicionX);
        arbol = new Hoja[5][];
        nombre = "Jugador de Football";
        descripcion = "";
        for (int i = 0; i < arbol.Length; i++)
        {
            if (i == 0)
            {
                arbol[i] = new Hoja[3];
            }
            else
            {
                arbol[i] = new Hoja[0];
            }
        }
        energia = 100;
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        InsertarHoja(new HojaJugadorDeFootballBase(jugadorDeFootballBase), 0);
        InsertarHoja(new HojaJugadorDeFootballV2(jugadorDeFootballV2), 0);
        InsertarHoja(new HojaJugadorDeFootballV1(jugadorDeFootballV1), 0);

        MostrarLanzadores();

    }
    protected override GameObject CargarLanzador(int i, int j)
    {
        return arbol[i][j].GetObjeto();
    }

}