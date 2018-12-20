using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente a la hoja de habilidad del jugador de football v2. En esta se mantiene 
/// la logica para el aprendizaje de habilidades y su gestion a medida que el jugador vaya ganando experiencia
/// </summary>
public class CartaJugadorDeFootballV2 : Carta {

    private JugadorDeFootballV2 jugador;

    public CartaJugadorDeFootballV2(GameObject unObjeto)
    {
        nombre = "Jugador de Football Medio";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        jugador = objeto.GetComponent<JugadorDeFootballV2>();
        jugador.SetVelocidad(-2f);
        jugador.SetCostoEnergia(50);
        unObjeto.GetComponent<ObjetoTablero>().nivel = nivel;
        unObjeto.GetComponent<ObjetoTablero>().nombre = nombre;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
