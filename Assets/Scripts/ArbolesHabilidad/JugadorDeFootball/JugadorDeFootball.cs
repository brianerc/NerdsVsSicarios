using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente de gestionar los distintos jugadores de football sicarios
/// </summary>
public class JugadorDeFootball : Mazo
{
    public GameObject jugadorDeFootballBase;
    public GameObject jugadorDeFootballV1;
    public GameObject jugadorDeFootballV2;

    protected override void Inicializar()
    {
        posicionX = (-posicionX);
        nombre = "Jugador de Football";
        descripcion = "";
        energia = 100;
        cantidadRegeneracionEnergia = 30;
        tiempoRegeneracionEnergia = 5;
        mazo = new List<Carta>();

        InsertarCarta(new CartaJugadorDeFootballBase(jugadorDeFootballBase));
        InsertarCarta(new CartaJugadorDeFootballV2(jugadorDeFootballV2));
        InsertarCarta(new CartaJugadorDeFootballV1(jugadorDeFootballV1));

        MostrarLanzadores();

    }

}