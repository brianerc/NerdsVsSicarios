using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente a la hoja de habilidad del jugador de football v1. En esta se mantiene 
/// la logica para el aprendizaje de habilidades y su gestion a medida que el jugador vaya ganando experiencia
/// </summary>
public class HojaJugadorDeFootballV1 : Hoja {

    private JugadorDeFootballV1 jugador;

    public HojaJugadorDeFootballV1(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football V1";
        descripcion = "";
        aprendida = true;
        jugador = unObjeto.GetComponent<JugadorDeFootballV1>();
        jugador.SetDaño(2);
        jugador.SetVida(10);
        jugador.SetVelocidad(-4f);
        objeto = unObjeto;
        jugador.SetCostoEnergia(25);
    }

    void Update () {
		
	}
}
