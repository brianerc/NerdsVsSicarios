using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase correspondiente a la hoja de habilidad del jugador de football base. En esta se mantiene 
/// la logica para el aprendizaje de habilidades y su gestion a medida que el jugador vaya ganando experiencia
/// </summary>
public class HojaJugadorDeFootballBase : Hoja
{
    private JugadorDeFootballBase jugador;

    public HojaJugadorDeFootballBase(GameObject unObjeto)
    {
        nivel = 1;
        nombre = "Jugador de Football Base";
        descripcion = "";
        aprendida = true;
        jugador = unObjeto.GetComponent<JugadorDeFootballBase>();
        jugador.SetDaño(4);
        jugador.SetVida(10);
        jugador.SetTiempo(1);
        jugador.SetVelocidad(-3f);
        jugador.SetCostoEnergia(75);
        objeto = unObjeto;
    }
    public override bool EsEstructura()
    {
        return true;
    }
}
