﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente a la hoja de habilidad del jugador de football v1. En esta se mantiene 
/// la logica para el aprendizaje de habilidades y su gestion a medida que el jugador vaya ganando experiencia
/// </summary>
public class CartaJugadorDeFootballV1 : Carta {

    private JugadorDeFootballV1 jugador;

    public CartaJugadorDeFootballV1(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football Base";
        descripcion = "";
        aprendida = true;
        jugador = unObjeto.GetComponent<JugadorDeFootballV1>();
        jugador.SetDaño(2);
        jugador.SetVida(10);
        jugador.SetVelocidad(-4f);
        objeto = unObjeto;
        jugador.SetCostoEnergia(25);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }

    void Update () {
		
	}
}