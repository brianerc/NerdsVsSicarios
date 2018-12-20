using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente a la hoja de habilidad del jugador de football base. En esta se mantiene 
/// la logica para el aprendizaje de habilidades y su gestion a medida que el jugador vaya ganando experiencia
/// </summary>
public class CartaJugadorDeFootballBase : Carta
{
    private JugadorDeFootballBase jugador;

    public CartaJugadorDeFootballBase(GameObject unObjeto)
    {
        nombre = "Jugador de Football Estrella";
        descripcion = "";
        aprendida = true;
        jugador = unObjeto.GetComponent<JugadorDeFootballBase>();
        jugador.SetVelocidad(-3f);
        jugador.SetCostoEnergia(75);
        objeto = unObjeto;
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}
