using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente a la hoja de habilidad del jugador de football v2. En esta se mantiene 
/// la logica para el aprendizaje de habilidades y su gestion a medida que el jugador vaya ganando experiencia
/// </summary>
public class HojaJugadorDeFootballV2 : Hoja {

    private JugadorDeFootballV2 jugador;

    public HojaJugadorDeFootballV2(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football V2";
        descripcion = "";
        aprendida = true;
        objeto = unObjeto;
        jugador = objeto.GetComponent<JugadorDeFootballV2>();
        jugador.SetDaño(4);
        jugador.SetVida(10);
        jugador.SetTiempo(1);
        jugador.SetVelocidad(-2f);
        jugador.SetCostoEnergia(50);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
